using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

	private ParticleSystem ps;	

	void Start(){
		ps = GetComponent<ParticleSystem> ();	
		ps.Play ();								
		Destroy (gameObject, ps.duration);		
	}
}
