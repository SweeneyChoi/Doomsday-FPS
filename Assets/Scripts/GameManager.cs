using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	static public GameManager gm;				

	public int TargetScore = 5;			
	public enum GameState 				
	{Playing,GameOver,Winning};
	public GameState gameState;			
	public GameObject player;			

	public GameObject playingCanvas;	
	public Text scoreText;				
	public Text timeText;				
	public Slider healthSlider;			
	public Image hurtImage;				

	public AudioClip gameWinAudio;				
	public AudioClip gameOverAudio;				
	public GameObject gameResultCanvas;			
	public GameObject mobileControlRigCanvas;	

	public GameObject firstUserText;	
	public GameObject secondUserText;	
	public GameObject thirdUserText;	
	public GameObject userText;			
	public Text gameMessage;			

	public bool lockCursor = true;		
	private bool m_cursorIsLocked;		

	private int currentCoinNum;
	private int maxCoinNum = 6;

	private int currentScore;			
	private float startTime;			
	private float currentTime;			
	private PlayerHealth playerHealth;	

	private bool cursor;					
	private AudioListener audioListener;	
	private Color flashColor = new Color (1.0f, 0.0f, 0.0f, 0.3f);	
	private float flashSpeed = 2.0f;								

	private UserData firstUserData;		
	private UserData secondUserData;	
	private UserData thirdUserData;		
	private UserData currentUserData;	
	private UserData[] userDataArray = new UserData[4];

	private bool isGameOver=false;		

	//初始化函数
	void Start () {
		if (gm == null)			
			gm = GetComponent<GameManager> ();
		if (player == null)		
			player = GameObject.FindGameObjectWithTag ("Player");

		if(GameObject.FindGameObjectWithTag ("MainCamera")!=null)
			audioListener = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioListener> ();

		gm.gameState = GameState.Playing;	
		currentScore = 0;					
		currentCoinNum = maxCoinNum;
		startTime = Time.time;				

		if(player!=null)
			playerHealth = player.GetComponent<PlayerHealth> ();	
		if (playerHealth) {
			healthSlider.maxValue = playerHealth.startHealth;
			healthSlider.minValue = 0;
			healthSlider.value = playerHealth.currentHealth;
		}

		playingCanvas.SetActive (true);		
		gameResultCanvas.SetActive(false);	

		if(PlayerPrefs.GetString("Username")=="")	
			PlayerPrefs.SetString("Username","No one");

		if (PlayerPrefs.GetString ("FirstUser") != "") {
			firstUserData = new UserData (PlayerPrefs.GetString ("FirstUser"));
		} else
			firstUserData = new UserData ();
		if (PlayerPrefs.GetString ("SecondUser") != "") {
			secondUserData = new UserData (PlayerPrefs.GetString ("SecondUser"));
		} else
			secondUserData = new UserData ();
		if (PlayerPrefs.GetString ("ThirdUser") != "") {
			thirdUserData = new UserData (PlayerPrefs.GetString ("ThirdUser"));
		} else
			thirdUserData = new UserData ();

		if(audioListener!=null)
			audioListener.enabled = (PlayerPrefs.GetInt ("SoundOff") != 1);

		m_cursorIsLocked = lockCursor;
	}

	void Update () {

		hurtImage.color = Color.Lerp (
			hurtImage.color, 
			Color.clear, 
			flashSpeed * Time.deltaTime
		);

		//根据游戏状态执行不同的操作
		switch (gameState) {	
		//游戏进行时
		case GameState.Playing:		
			if (playerHealth!=null&&playerHealth.isAlive == false)			
				gm.gameState = GameState.GameOver;
			else if (currentCoinNum == 0) {		
				GameObject.Destroy (GameObject.Find ("egoza_ograda1"));
				GameObject.Destroy (GameObject.Find ("egoza_ograda2"));
				GameObject.Destroy (GameObject.Find ("egoza_ograda3"));
				GameObject.Destroy (GameObject.Find ("egoza_ograda4"));
			}
			//否则，当前游戏状态还是游戏进行时状态
			else {							
				scoreText.text = "得 分 ： " + currentScore;	
				if(gm.playerHealth!=null)
					healthSlider.value = gm.playerHealth.currentHealth;	
				currentTime = Time.time - startTime;				
				timeText.text = "战 斗 时 间 ： " + currentTime.ToString ("0.00");	
				if (mobileControlRigCanvas != null)					
					mobileControlRigCanvas.SetActive (true);
			}
			if(lockCursor)
				InternalLockUpdate ();	
			break;
		//游戏胜利
		case GameState.Winning:
			if (!isGameOver) {
				AudioSource.PlayClipAtPoint (gameWinAudio, player.transform.position);	
				Cursor.visible = true;					
				playingCanvas.SetActive (false);		
				gameResultCanvas.SetActive (true);		
				if (mobileControlRigCanvas != null)		
					mobileControlRigCanvas.SetActive (false);
				isGameOver = true;
				EditGameOverCanvas();	
			}
			ReleaseCursorLock ();		
			break;
		case GameState.GameOver:
			if (!isGameOver) {
				AudioSource.PlayClipAtPoint (gameOverAudio, player.transform.position);	
				Cursor.visible = true;					
				playingCanvas.SetActive (false);		
				gameResultCanvas.SetActive (true);		
				if (mobileControlRigCanvas != null)		
					mobileControlRigCanvas.SetActive (false);
				isGameOver = true;
				EditGameOverCanvas ();	
			}
			ReleaseCursorLock ();		
			break;
		}
	}


	void EditGameOverCanvas(){

		currentUserData = new UserData (PlayerPrefs.GetString("Username") + " 0 " + currentScore.ToString() + " " + currentTime.ToString("0.00"));
		currentUserData.isUser = true;			

		userDataArray [0] = currentUserData;	
		int arrayLength = 1;
		if (firstUserData.order != "0")
			userDataArray [arrayLength++] = firstUserData;
		if (secondUserData.order != "0")
			userDataArray [arrayLength++] = secondUserData;
		if (thirdUserData.order != "0")
			userDataArray [arrayLength++] = thirdUserData;


		mySort (arrayLength);

		foreach (UserData i in userDataArray) {
			if (i.isUser == true) {
				currentUserData = i;
				break;
			}
		}

		switch (currentUserData.order) {
		case "1":
			gameMessage.text = "恭喜你荣登排行榜榜首！";
			break;
		case "2":
			gameMessage.text = "恭喜你荣登排行榜榜眼！";
			break;
		case "3":
			gameMessage.text = "恭喜你荣登排行榜探花！";
			break;
		default:
			gameMessage.text = "";
			break;
		}


		Text[] texts;
		if (arrayLength > 0) {
			PlayerPrefs.SetString ("FirstUser", userDataArray [0].DataToString ());
			texts = firstUserText.GetComponentsInChildren<Text> ();
			LeaderBoardChange(texts,userDataArray [0]);
			arrayLength--;
		}
		if (arrayLength > 0) {
			PlayerPrefs.SetString ("SecondUser", userDataArray [1].DataToString ());
			texts = secondUserText.GetComponentsInChildren<Text> ();
			LeaderBoardChange(texts,userDataArray [1]);
			arrayLength--;
		}
		if (arrayLength > 0) {
			PlayerPrefs.SetString ("ThirdUser", userDataArray [2].DataToString ());
			texts = thirdUserText.GetComponentsInChildren<Text> ();
			LeaderBoardChange(texts,userDataArray [2]);
			arrayLength--;
		}


		if (currentUserData.order != "1" && currentUserData.order != "2" && currentUserData.order != "3") {
			texts = userText.GetComponentsInChildren<Text> ();
			LeaderBoardChange (texts, currentUserData);
		} else {
			userText.SetActive (false);
		}

	}


	void mySort(int arrayLength){
		UserData temp;
		for (int i = 0; i < arrayLength; i++) {
			for (int j = i+1; j < arrayLength; j++) {
				if (userDataArray [i] < userDataArray [j]) {
					temp = userDataArray [j];
					userDataArray [j] = userDataArray [i];
					userDataArray [i] = temp;
				}
			}
		}

		for (int i = 0; i < arrayLength; i++)
			userDataArray [i].order = (i + 1).ToString();
	}


	void LeaderBoardChange(Text[] texts,UserData data){
		texts [0].text = data.username;
		texts [1].text = data.score.ToString();
		texts [2].text = data.time.ToString();
		if (data.isUser) {
			texts [0].fontStyle = FontStyle.Bold;
			texts [1].fontStyle = FontStyle.Bold;
			texts [2].fontStyle = FontStyle.Bold;
		}
	}

	//玩家得分
	public void AddScore(int value){
		currentScore += value;
	}
	public void SubtractCoinNum(){
		currentCoinNum--;
	}
	//玩家扣血
	public void PlayerTakeDamage(int value){
		if (playerHealth != null)
			playerHealth.TakeDamage(value);
		hurtImage.color = flashColor;
	}
	//玩家加血
	public void PlayerAddHealth(int value){
		if (playerHealth != null)
			playerHealth.AddHealth(value);
	}

	//重新加载游戏场景
	public void PlayAgain(){
		SceneManager.LoadScene("GamePlay");
	}
	//加载游戏开始场景
	public void BackToMain(){
		SceneManager.LoadScene("GameStart");
	}

	//更新鼠标锁定状态
	private void InternalLockUpdate()
	{
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			m_cursorIsLocked = false;
		}
		else if(Input.GetMouseButtonUp(0))
		{
			m_cursorIsLocked = true;
		}

		if (m_cursorIsLocked)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else if (!m_cursorIsLocked)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
	//显示鼠标
	private void ReleaseCursorLock()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}
