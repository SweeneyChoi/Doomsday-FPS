using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombieSensor : MonoBehaviour {

	public float SoundRange = 15.0f;	
	public float SightRange = 25.0f;	
	public float SightAngle = 60;		
	public float SensorInterval = 0.5f;	

	private float senseTimer = 0.0f;	

	private Transform zombieTransform;	
	private Transform nearbyPlayer;		
	private Transform zombieEye;		

	void Start()
	{
		zombieTransform = transform;						
		zombieEye = transform.Find ("eye").transform;
	}

	void FixedUpdate()
	{
		if (senseTimer >= SensorInterval) {
			senseTimer = 0;
			SenseNearbyPlayer ();
		}
		senseTimer += Time.deltaTime;

	}

	void SenseNearbyPlayer()
	{
		nearbyPlayer = null;
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) {
			PlayerHealth ph = player.GetComponent<PlayerHealth> ();
			if (ph != null && ph.isAlive)
			{
				float dist = Vector3.Distance (player.transform.position, zombieTransform.position);

				if (dist < SoundRange) {
					nearbyPlayer = player.transform;
				}
					
				if (dist < SightRange) {
					Vector3 direction = player.transform.position - zombieTransform.position;
						float degree = Vector3.Angle (direction, zombieTransform.forward);

					if (degree < SightAngle / 2 && degree > -SightAngle / 2) {
						Ray ray = new Ray();	
						ray.origin = zombieEye.position;		
						ray.direction = direction;		
						RaycastHit hitInfo;		
						if (Physics.Raycast (ray, out hitInfo, SightRange)) {
							if (hitInfo.transform == player.transform) {
								nearbyPlayer = player.transform;
							}
						}
					}
				}
			}
		}
	}
		
	public Transform getNearbyPlayer()
	{
		return nearbyPlayer;
	}
}
