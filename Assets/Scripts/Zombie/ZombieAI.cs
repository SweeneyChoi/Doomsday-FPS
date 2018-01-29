using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

	public enum FSMState
	{
		Wander,		
		Seek,		
		Chase,		
		Attack,		
		Dead,		
	}



	public float wanderSpeed = 0.9f;			
	public float runSpeed = 4.0f;				
	public float wanderScope = 15.0f;			
	public float seekDistance = 25.0f;			
	public float disappearTime = 3.0f;			

	public float attackRange = 1.5f;			
	public float attackFieldOfView = 60.0f;		
	public float attackInterval = 0.8f;			
	public int attackDamage = 10;				
	public AudioClip zombieAttackAudio; 		

	public FSMState currentState;				
	public float currentSpeed = 0.0f;			

	public bool autoInit = false;				

	private Vector3 previousPos = Vector3.zero;	
	private float stopTime = 0;					
	private float attackTimer = 0.0f;			
	private float disappearTimer = 0.0f;		
	private bool disappeared = false;			

	private UnityEngine.AI.NavMeshAgent		agent;			
	private Animator			animator;		
	private Transform 			zombieTransform;
	private ZombieHealth	zombieHealth;		
	private ZombieSensor zombieSensor;			
	private ZombieRender	zombieRender;		
	private Transform targetPlayer;				

	private bool firstInDead = true;			


	void OnEnable()
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		animator = GetComponent<Animator>();
		zombieHealth = GetComponent<ZombieHealth> ();
		zombieSensor = GetComponentInChildren<ZombieSensor> ();
		zombieRender = GetComponent<ZombieRender> ();
		zombieTransform = transform;

		targetPlayer = null;

		currentState = FSMState.Dead;

		agent.enabled = false;

		if (autoInit)
			Born ();
	}

	public void Born(Vector3 pos)
	{
		zombieTransform.position = pos;
		Born ();
	}

	public void Born()
	{

		targetPlayer = null;

		currentState = FSMState.Wander;

		zombieHealth.currentHP = zombieHealth.maxHP;

		agent.enabled = true;
		agent.ResetPath ();


		animator.applyRootMotion = false;
		GetComponent<CapsuleCollider> ().enabled = true;
		animator.SetTrigger("toReborn");

		disappearTimer = 0;
		disappeared = false;
		firstInDead = true;
		currentState = FSMState.Wander;
	}

	void Disable()
	{
		zombieTransform.gameObject.SetActive (false);
	}


	void FixedUpdate()
	{
		FSMUpdate ();
	}


	void FSMUpdate()
	{

		switch (currentState)
		{
		case FSMState.Wander: 
			UpdateWanderState();
			break;
		case FSMState.Seek:
			UpdateSeekState();
			break;
		case FSMState.Chase:
			UpdateChaseState();
			break;
		case FSMState.Attack:
			UpdateAttackState();
			break;
		case FSMState.Dead:
			UpdateDeadState ();
			break;
		}

		if (currentState != FSMState.Dead && !zombieHealth.IsAlive) 
		{
			currentState = FSMState.Dead;
		}
	}


	protected bool AgentDone()
	{
		return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
	}


	private void setMaxAgentSpeed(float maxSpeed)
	{
		Vector3 targetVelocity = Vector3.zero;
		if (agent.desiredVelocity.magnitude > maxSpeed) {
			targetVelocity = agent.desiredVelocity.normalized * maxSpeed;
		} else {
			targetVelocity = agent.desiredVelocity;
		}
		agent.velocity = targetVelocity;
		currentSpeed = agent.velocity.magnitude;


		animator.SetFloat("Speed", currentSpeed);

	}


	private void caculateStopTime()
	{
		if (previousPos == Vector3.zero) 
		{
			previousPos = zombieTransform.position;
		}
		else 
		{
			Vector3 posDiff = zombieTransform.position - previousPos;
			if (posDiff.magnitude > 0.5) {
				previousPos = zombieTransform.position;
				stopTime = 0.0f;
			} else {
				stopTime += Time.deltaTime;
			}
		}
	}


	void UpdateWanderState()
	{

		targetPlayer = zombieSensor.getNearbyPlayer ();
		if ( targetPlayer != null) {
			currentState = FSMState.Chase;
			agent.ResetPath ();
			return;
		}


		if (zombieHealth.getDamaged) {
			currentState = FSMState.Seek;
			agent.ResetPath ();
			return;
		}


		if (AgentDone () ) {
			Vector3 randomRange = new Vector3 ( (Random.value - 0.5f) * 2 * wanderScope, 
											0, (Random.value - 0.5f) * 2 * wanderScope);
			Vector3 nextDestination = zombieTransform.position + randomRange;
			agent.destination = nextDestination;
		} 

		setMaxAgentSpeed(wanderSpeed);


		caculateStopTime();


		if(stopTime > 1.0f)
		{
			Vector3 nextDestination = zombieTransform.position 
				- zombieTransform.forward * (Random.value) * wanderScope;
			agent.destination = nextDestination;
		}


		if(zombieRender!=null)
			zombieRender.SetNormal();

	}


	void UpdateSeekState()
	{

		targetPlayer = zombieSensor.getNearbyPlayer ();
		if ( targetPlayer != null) {
			currentState = FSMState.Chase;
			agent.ResetPath ();
			return;
		}

		if (zombieHealth.getDamaged) {
			Vector3 seekDirection = zombieHealth.damageDirection;
			agent.destination = zombieTransform.position 
				+ seekDirection * seekDistance;

			zombieHealth.getDamaged = false;	
		}


		if (AgentDone () || stopTime > 1.0f ) {
			currentState = FSMState.Wander;
			agent.ResetPath ();
			return;
		} 

		setMaxAgentSpeed(runSpeed);


		if(zombieRender!=null)
			zombieRender.SetCrazy();


		caculateStopTime();

	}


	void UpdateChaseState()
	{

		targetPlayer = zombieSensor.getNearbyPlayer ();
		if (targetPlayer == null) {
			currentState = FSMState.Wander;
			agent.ResetPath ();
			return;
		}

		if (Vector3.Distance(targetPlayer.position, zombieTransform.position)<=attackRange) {
			currentState = FSMState.Attack;
			agent.ResetPath ();
			return;
		}


		agent.SetDestination (targetPlayer.position);


		setMaxAgentSpeed(runSpeed);


		if(zombieRender!=null)
			zombieRender.SetCrazy();


		caculateStopTime();
	}

	void UpdateAttackState()
	{

		targetPlayer = zombieSensor.getNearbyPlayer ();
		if (targetPlayer == null) {
			currentState = FSMState.Wander;
			agent.ResetPath ();
			animator.SetBool ("isAttack", false);
			return;
		}

		if (Vector3.Distance(targetPlayer.position, zombieTransform.position)>attackRange) {
			currentState = FSMState.Chase;
			agent.ResetPath ();
			animator.SetBool ("isAttack", false);
			return;
		}



		PlayerHealth ph = targetPlayer.GetComponent<PlayerHealth> ();
		if (ph != null)
		{

			Vector3 direction = targetPlayer.position - zombieTransform.position;
			float degree = Vector3.Angle (direction, zombieTransform.forward);
			if (degree < attackFieldOfView / 2 && degree > -attackFieldOfView / 2) {
				animator.SetBool ("isAttack", true);
				if (attackTimer > attackInterval) {
					attackTimer = 0;
					if (zombieAttackAudio != null)				
						AudioSource.PlayClipAtPoint (zombieAttackAudio, zombieTransform.position);
					GameManager.gm.PlayerTakeDamage (attackDamage);
				}
				attackTimer += Time.deltaTime;
			} else {

				animator.SetBool ("isAttack", false);
				zombieTransform.LookAt(targetPlayer);
			}
		}


		agent.SetDestination (targetPlayer.position);


		if(zombieRender!=null)
			zombieRender.SetCrazy();


		setMaxAgentSpeed(runSpeed);

	}
		
	void UpdateDeadState()
	{

		if (!disappeared) {

			if ( disappearTimer > disappearTime) {
				zombieTransform.gameObject.SetActive (false);
				disappeared = true;
			}
			disappearTimer += Time.deltaTime;
		}

		if (firstInDead) {
			firstInDead = false;

			agent.ResetPath ();
			agent.enabled = false;
			GetComponent<CapsuleCollider> ().enabled = false;

			animator.applyRootMotion = true;
			animator.SetTrigger ("toDie");

			disappearTimer = 0;
			disappeared = false;


			if(zombieRender!=null)
				zombieRender.SetNormal();
			animator.ResetTrigger("toReborn");
		}

	}
}