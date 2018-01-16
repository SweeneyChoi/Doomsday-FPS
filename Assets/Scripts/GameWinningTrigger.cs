using UnityEngine;
using System.Collections;

public class GameWinningTrigger : MonoBehaviour {

	void OnTriggerEnter(){
		GameManager.gm.gameState = GameManager.GameState.Winning;
	}
}
