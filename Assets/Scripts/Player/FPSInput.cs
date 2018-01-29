using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
	public float moveSpeed = 6.0f;
	public float rotSpeed = 15.0f;
	public float jumpSpeed = 15.0f;
	public float gravity = -9.8f;
	public float terminalVelocity = -20.0f;
	public float minFall = -1.5f;
	public float pushForce = 3.0f;

	private float _vertSpeed;
	private ControllerColliderHit _contact;

	private CharacterController _charController;
	Animator anim;
	
	void Start() {
		_vertSpeed = minFall;

		_charController = GetComponent<CharacterController>();
		anim = GetComponent<Animator> ();
	}
	
	void Update() {
		if (GameManager.gm == null || GameManager.gm.gameState == GameManager.GameState.Playing) {
			float deltaX = CrossPlatformInputManager.GetAxis ("Horizontal") * moveSpeed;
			float deltaZ = CrossPlatformInputManager.GetAxis ("Vertical") * moveSpeed;
			if (deltaX != 0.0f || deltaZ != 0.0f) {
				if (anim != null)
					anim.SetBool ("isMove", true);
			} else {
				if (anim != null)
					anim.SetBool ("isMove", false);
			}
			Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
			movement = Vector3.ClampMagnitude (movement, moveSpeed);

		bool hitGround = false;
		RaycastHit hit;
		if (_vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit)) {
			float check = (_charController.height + _charController.radius) / 1.9f;
			hitGround = hit.distance <= check;	
			if (hitGround == false && anim != null)
				anim.SetBool ("isJump", false);
		}
				
		if (hitGround) {
				if (CrossPlatformInputManager.GetButtonDown("Jump")) {
				_vertSpeed = jumpSpeed;
					if (anim != null)
						anim.SetBool ("isJump", true);
			} else {
				_vertSpeed = minFall;
					if(anim != null)
						anim.SetBool ("isJump", false);
			}
		} else {
			_vertSpeed += gravity * 5 * Time.deltaTime;
			if (_vertSpeed < terminalVelocity) {
				_vertSpeed = terminalVelocity;
			}
			if (_contact != null ) {	
			}
					
			if (_charController.isGrounded) {
				if (Vector3.Dot(movement, _contact.normal) < 0) {
					movement = _contact.normal * moveSpeed;
				} else {
					movement += _contact.normal * moveSpeed;
				}
			}
		}

			movement.y = _vertSpeed;

			movement *= Time.deltaTime;
			movement = transform.TransformDirection (movement);
			_charController.Move (movement);
		}
	}
	void OnControllerColliderHit(ControllerColliderHit hit) {
		_contact = hit;

		Rigidbody body = hit.collider.attachedRigidbody;
		if (body != null && !body.isKinematic) {
			body.velocity = hit.moveDirection * pushForce;
		}
	}
}
