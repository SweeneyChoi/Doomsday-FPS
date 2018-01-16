using UnityEngine;
using System.Collections;

public class DoorOpenDevice : MonoBehaviour {
	public string animation;
	private Animation anim;
	private bool _open;
	public void Start(){
		anim = GetComponent<Animation> ();
	}
	public void Activate(){
		if (!_open) {
			anim.Play (animation);
			_open = true;
		}
	}
}
