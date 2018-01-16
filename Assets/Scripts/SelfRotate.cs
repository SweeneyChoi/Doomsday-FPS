using UnityEngine;
using System.Collections;

public class SelfRotate : MonoBehaviour {

	public float rotateSpeed = 40.0f;	

	void Update () {
		transform.Rotate (Vector3.up, -Time.deltaTime * rotateSpeed, Space.World);
	}
}
