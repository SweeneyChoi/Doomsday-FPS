using UnityEngine;
using System.Collections;

public class ZombieGenerator : MonoBehaviour {



	public Transform[] zombieSpawnTransform;	
	public int maximumInstanceCount = 9;		
	public float minGenerateTimeInterval = 5.0f;	
	public float maxGenerateTimeInterval = 20.0f;	
	public GameObject zombiePrefab;					

	private float nextGenerationTime = 0.0f;		
	private float timer = 0.0f;						
	private GameObject[] instances;					
	public static Vector3 defaultPosition = new Vector3(33, -6, -8);	
 
	void Start () {

		instances = new GameObject[maximumInstanceCount];

		for(int i = 0; i < maximumInstanceCount; i++) {

			GameObject zombie = Instantiate (zombiePrefab, 
				defaultPosition, Quaternion.identity) as GameObject;

			zombie.SetActive (false);

			instances [i] = zombie;
		}
	}


	private GameObject GetNextAvailiableInstance ()   {
		for(var i = 0; i < maximumInstanceCount; i++) {
			if(!instances[i].activeSelf)
			{
				return instances[i];
			}
		}
		return null;
	}

	private bool generate(Vector3 position)
	{

		GameObject zombie = GetNextAvailiableInstance ();
		if (zombie != null) {

			zombie.SetActive (true);

			zombie.GetComponent<ZombieAI> ().Born (position);
			return true;
		}
		return false;
	}

	void Update () {   
		if (GameManager.gm.gameState != GameManager.GameState.Playing)
			return;
		

		if (timer > nextGenerationTime) {


			int i = Random.Range(0, zombieSpawnTransform.Length);

			generate (zombieSpawnTransform [i].position);

			nextGenerationTime = Random.Range (minGenerateTimeInterval, maxGenerateTimeInterval);

			timer = 0;
		}
		timer += Time.deltaTime;

	}
}
