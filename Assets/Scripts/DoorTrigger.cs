using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {
	[SerializeField] private GameObject target;

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == "Player") {
			target.SendMessage ("Activate");
		}
	}
}
