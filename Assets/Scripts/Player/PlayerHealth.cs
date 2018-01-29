using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startHealth = 100;	
	public int currentHealth;		

	public GameObject gun;				

	public bool isAlive { get { return currentHealth > 0; } }

	private Animator anim;
	private PlayerWeaponSwitcher playerWeaponSwitcher;	
	private IKController userIKController;

	void Start () {
		currentHealth = startHealth;
		anim = GetComponent<Animator> ();
		playerWeaponSwitcher = GetComponent<PlayerWeaponSwitcher> ();
		userIKController = GetComponent<IKController> ();
	}

	//扣血函数
	public void TakeDamage(int damage){
		currentHealth -= damage;
		if (currentHealth < 0)
			currentHealth = 0;

		//如果玩家死亡
		if (currentHealth == 0) {
			if (anim != null) {
				anim.SetBool ("isDead", true);
				//允许动画控制器，控制玩家的运动
				anim.applyRootMotion = true;
			}

			//禁用IK
			if (userIKController != null) {
				userIKController.enabled = false;
			}

			//禁用玩家所有的枪械
			if (playerWeaponSwitcher != null) {
				foreach (Transform trans in playerWeaponSwitcher.weaponList) {
					trans.gameObject.SetActive (false);
				}
			} else if(gun!=null) {
				gun.SetActive (false);
			}
		}
	}

	//加血函数
	public void AddHealth(int value){
		currentHealth += value;
		if (currentHealth > startHealth)	
			currentHealth = startHealth;
	}
}
