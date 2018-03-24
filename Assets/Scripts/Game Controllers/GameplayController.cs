using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameplayController : MonoBehaviour {

	public static GameplayController instance;

	[SerializeField]
	private Text scoreText, coinText, lifeText;

	[SerializeField]
	private GameObject pausePanel;

	void Awake(){
		makeInstance ();
	}
	
	void makeInstance(){

		if (instance == null) {
			instance = this;
		}
	}

	public void pauseTheGame(){
		Time.timeScale = 0;
		pausePanel.SetActive (true);
	}

	public void ResumeGame(){
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void QuitGame(){
		Time.timeScale = 1f;
		Application.LoadLevel ("MainMenu");
	}
}
