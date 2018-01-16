using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverEffects : MonoBehaviour
{
	public Image darkImage;			
	public GameObject enemyPrefab;	

    private Transform cameraTransform;		
    private Vector3 direction;				
    private GameObject player;				
    private GameObject[] enemies;			
	private GameObject[] gameoverEnemies;	

    private bool initialized;			
	private bool gameover;				
	private bool rankingPanelActive;	

	public GameObject rankingPanel;		


	void Start(){
		initialized = false;
		gameover = false;
		rankingPanelActive = false;
	}


    void Init()
    {
		initialized = true;		
		player = GameObject.FindGameObjectWithTag("Player");	
		enemies = GameObject.FindGameObjectsWithTag("Enemy");	

		GameObject.Destroy (GameObject.Find ("char_robotGuard_body"));	
		GameObject.Destroy (GameObject.Find ("char_robotGuard_skeleton"));
		GameObject.Destroy (GameObject.Find ("Gun"));
		GameObject.Destroy (GameObject.Find ("Grenade Launcher"));
		foreach (GameObject enemy in enemies)			
			GameObject.Destroy (enemy);
       	direction = new Vector3(3.0f, 3.0f, 5.0f);		

		Camera playerCamera = player.GetComponentInChildren<Camera> ();	
		Camera gameOverCamera = GameObject.Find ("GameOverCamera").GetComponent<Camera> ();	
		cameraTransform = gameOverCamera.transform;	

		cameraTransform.position = playerCamera.transform.position;			
		cameraTransform.eulerAngles = playerCamera.transform.eulerAngles;	

		playerCamera.enabled = false;	
		gameOverCamera.enabled = true;	
    }

	//摄像机切换行为
	void CameraBehavior(bool win)
    {
		if (!win) {	
			rankingPanel.SetActive (rankingPanelActive);
			Invoke ("enablePanel", 3);		
			darkImage.color = Color.Lerp (	
				darkImage.color, 
				Color.clear, 
				0.2f * Time.deltaTime
			);
		}

		cameraTransform.position = Vector3.Lerp (
			cameraTransform.position, 
			player.transform.position + direction, 
			0.01f
		);

        cameraTransform.LookAt(player.transform);
    }

	void enablePanel(){
		rankingPanelActive = true;	
	}


	void GameOver(){
		gameover = true;	
		darkImage.color = Color.black;	

		Vector3 enemyCenter = new Vector3 (
			player.transform.position.x - direction.x,
			player.transform.position.y,
			player.transform.position.z - direction.z);
		
		Vector3 enemyVector = new Vector3 (direction.z, 0, -direction.x);
		enemyVector.Normalize ();

		gameoverEnemies = new GameObject[7];

		for (int i = -3; i <= 3; i++) {
			GameObject _enemy = (GameObject)GameObject.Instantiate (
				enemyPrefab,
				enemyCenter + i * enemyVector * 1.5f,
				Quaternion.identity);
			_enemy.transform.LookAt (player.transform.position + direction);			
			_enemy.transform.eulerAngles = new Vector3 (0, _enemy.transform.eulerAngles.y, 0);	
			gameoverEnemies [i + 3] = _enemy;
		}
			
	}


    void Update()
    {
        switch (GameManager.gm.gameState)
        {
        case GameManager.GameState.Playing:	
            return;
		case GameManager.GameState.Winning:	
			if (!initialized) Init ();		
			CameraBehavior (true);			
            break;
		case GameManager.GameState.GameOver:
			if (!initialized) Init ();		
			CameraBehavior (false);			
			if (!gameover) GameOver ();		
            break;
        }
    }
}
