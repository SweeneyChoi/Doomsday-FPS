using UnityEngine;
using System.Collections;

public class ZombieHealth :MonoBehaviour{

	public int currentHP = 10;		
	public int maxHP = 10;			
	public int killScore = 5;		
	public AudioClip enemyHurtAudio;		

	[HideInInspector]
	public Vector3 damageDirection = Vector3.zero;	
	[HideInInspector]
	public bool getDamaged = false;					

	public bool IsAlive {
		get {
			return currentHP > 0;
		}
	}

	public void TakeDamage(int damage, Vector3 shootPosition){
		if (!IsAlive)
			return;
		currentHP -= damage;
		if (currentHP <= 0 ) currentHP = 0;
		if (IsAlive) {		
			getDamaged = true;
			damageDirection = shootPosition - transform.position;
			damageDirection.Normalize ();		
		} 
		else
		{		
			if (GameManager.gm != null) {	
				GameManager.gm.AddScore (killScore);
			}
		}

		if (enemyHurtAudio != null)				
			AudioSource.PlayClipAtPoint (enemyHurtAudio, transform.position);
	}

}
