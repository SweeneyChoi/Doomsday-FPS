using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class ZombieRender : MonoBehaviour {
	

	private Renderer[] rends;	
	private int rendCnt = 0;	

	void Start()
	{
		
		rends = GetComponentsInChildren<SkinnedMeshRenderer>();

		rendCnt = rends.Length;
	} 


	public void SetCrazy()
	{

		for(int i=0;i<rendCnt;i++)
			rends [i].material.SetFloat ("_RimBool", 1.0f);
	}


	public void SetNormal()
	{

		for(int i=0;i<rendCnt;i++)
			rends [i].material.SetFloat ("_RimBool", 0.0f);
	}

	public void SetCrazy2()
	{
		float rimBool = 1.0f;
		float rimPower = 3.0f;
		for(int i=0;i<rendCnt;i++)
		{
			Renderer rend = rends [i];
			rend.material.SetFloat ("_RimBool", rimBool);
			rend.material.SetFloat ("_RimPower", rimPower);
		}
	}

	public void SetNormal2()
	{
		float rimBool = 0.0f;
		float rimPower = 3.0f;
		for(int i=0;i<rendCnt;i++)
		{
			Renderer rend = rends [i];
			rend.material.SetFloat ("_RimBool", rimBool);
			rend.material.SetFloat ("_RimPower", rimPower);
		}

	}
}
