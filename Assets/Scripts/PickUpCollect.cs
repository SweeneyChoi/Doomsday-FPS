using UnityEngine;
using System.Collections;

public class PickUpCollect: MonoBehaviour {

	public enum PickUpType { score, health };	
	public PickUpType pickUpType;				
	public int value1 = 2;						
	public int value2 = 10;
	public AudioClip collectedAudio;			


	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == "Player") {	
			if (GameManager.gm != null) 		
			{
				if (pickUpType == PickUpType.score) {
					
					GameManager.gm.AddScore (value1);
					GameManager.gm.SubtractCoinNum ();
				}	
				else if(pickUpType==PickUpType.health)	
					GameManager.gm.PlayerAddHealth (value2);
			}
			if (collectedAudio!=null)	
				AudioSource.PlayClipAtPoint (collectedAudio, transform.position);
			Destroy(gameObject);		
		}
	}
}
