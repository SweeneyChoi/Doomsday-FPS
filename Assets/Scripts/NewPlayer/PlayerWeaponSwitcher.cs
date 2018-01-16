using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerWeaponSwitcher : MonoBehaviour {

	public Transform[] weaponList;	

	private IKController ikController;	
	private int currentIdx = 0;	
	private int weaponNum = 0;	

	void Start () {

		ikController = transform.GetComponent<IKController> ();	

		weaponNum = weaponList.Length;

		currentIdx = 0;

		changeNextWeapon ();
	}

	void Update () {

		if (CrossPlatformInputManager.GetButtonDown("Fire2")) {
			changeNextWeapon ();
		}
	}

	public void changeNextWeapon()
	{

		if (weaponNum <= 1) 
			return;


		int newIdx = (currentIdx + 1) % weaponNum;


		Transform newWeapon = weaponList [newIdx];
		Transform rightHand = newWeapon.Find ("RightHandObj");
		Transform leftHand  = newWeapon.Find ("LeftHandObj");
		Transform gunBarrelEnd = newWeapon.Find ("GunBarrelEnd");
		ikController.leftHandObj = leftHand;
		ikController.rightHandObj = rightHand;
		ikController.lookObj = gunBarrelEnd;


		newWeapon.gameObject.SetActive (true);
		weaponList [currentIdx].gameObject.SetActive (false);


		currentIdx = newIdx;
	}
}
