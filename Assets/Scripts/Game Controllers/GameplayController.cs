using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameplayController : MonoBehaviour {

	public static GameplayController instance;

	[SerializeField]
	private Text scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText;

	[SerializeField]
	private GameObject pausePanel, gameOverPanel;

	[SerializeField]
	private GameObject  readyButton;

	void Awake(){
		makeInstance ();
	}

	void Start(){
		Time.timeScale = 0f;
	}

	public void GameOverShowPanel( int finalScore, int finalCoinScore ){
		gameOverPanel.SetActive (true);
		gameOverScoreText.text = finalScore.ToString ();
		gameOverCoinText.text = finalCoinScore.ToString ();
		StartCoroutine (GameOverLoadMenu ());

	}

	IEnumerator GameOverLoadMenu(){
		yield return new WaitForSeconds (3f);
		Application.LoadLevel ("MainMenu");
	}

	public void PlayerDiedRestartTheGame(){
		StartCoroutine (PlayerDiedRestart());
	}

	IEnumerator PlayerDiedRestart(){
		yield return new WaitForSeconds (1f);
		Application.LoadLevel ("Gameplay");
	}	

	public void SetScore( int score ){
		scoreText.text = "x" + score;
	}

	public void setCoinScore( int coinScore ){
		coinText.text = "x" + coinScore;
	}

	public void setLifeScore( int lifeScore ){
		lifeText.text = "x" + lifeScore;
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

	public void StartTheGame(){
		Time.timeScale = 1f;
		readyButton.SetActive (false);
	}
}
