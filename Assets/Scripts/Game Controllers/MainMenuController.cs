using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void startGame(){

		GameManager.instance.gameStartedFromMainMenu = true;
		Application.LoadLevel ("Gameplay");
	}

	public void GoToHighScoreMenu(){
		Application.LoadLevel ("HighScoreScene");
	}

	public void OptionsMenu(){
		Application.LoadLevel("OptionsMenu");
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void MusicButton(){
		
	}
}
