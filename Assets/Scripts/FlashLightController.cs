using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class FlashLightController : MonoBehaviour {

	private Light mylight;

	void Start () {
		mylight = GetComponent<Light> ();
	}	

	void Update () {
		if (CrossPlatformInputManager.GetButtonDown ("Fire3")) {
			if (mylight.intensity < 0.1)
				mylight.intensity = 5f;
			else
				mylight.intensity = 0.0f;
		}
			
	}
}
