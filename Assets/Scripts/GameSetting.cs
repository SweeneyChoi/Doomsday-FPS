using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSetting : MonoBehaviour {
	
	public GameObject InitSubPanel;		
	public GameObject StartSubPanel;	
	public GameObject OptionSubPanel;	

	public InputField usernameInputField;	
	public Toggle soundToggle;				

	public void StartGame(){
		PlayerPrefs.SetString ("Username", usernameInputField.text);	
		SceneManager.LoadScene("GamePlay");								
	}
		
	public void SwitchSound(){
		if (soundToggle.isOn) PlayerPrefs.SetInt ("SoundOff", 0);	
		else PlayerPrefs.SetInt ("SoundOff", 1);					
	}
		
	public void ExitGame(){
		Application.Quit ();	
	}
		
	void Start () {
		ActiveInitPanel ();	
	}
		
	public void ActiveInitPanel(){
		InitSubPanel.SetActive (true);
		StartSubPanel.SetActive (false);
		OptionSubPanel.SetActive (false);
	}
		
	public void ActiveStartPanel(){
		InitSubPanel.SetActive (false);
		StartSubPanel.SetActive (true);
		OptionSubPanel.SetActive (false);
	}
		
	public void ActiveOptionPanel(){
		InitSubPanel.SetActive (false);
		StartSubPanel.SetActive (false);
		OptionSubPanel.SetActive (true);
	}
}
