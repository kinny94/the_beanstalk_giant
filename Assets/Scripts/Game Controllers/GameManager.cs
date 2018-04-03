using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[HideInInspector]
	public bool gameStartedFromMainMenu, gameRestartAfterPlayerDied;

	[HideInInspector]
	public int score, coinScore, lifeScore;

	void Awake () {
		MakeSingleton ();
	}

	void OnEnable() {
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {

		if (Application.loadedLevelName == "Gameplay") {

			if (gameRestartAfterPlayerDied) {

				GameplayController.instance.SetScore (score);
				GameplayController.instance.setCoinScore (coinScore);
				GameplayController.instance.setLifeScore (lifeScore);

				PlayerScore.scoreCount = score;
				PlayerScore.coinScore = coinScore;
				PlayerScore.lifeScore = lifeScore;

			} else if( gameStartedFromMainMenu ) {

				PlayerScore.scoreCount = 0;
				PlayerScore.coinScore = 0;
				PlayerScore.lifeScore = 2;

				GameplayController.instance.SetScore (0);
				GameplayController.instance.setCoinScore (0);
				GameplayController.instance.setLifeScore (2);

				GameplayController.instance.PlayerDiedRestartTheGame ();

			}
		}
	}

//	void OnLevelWasLoaded(){
//		
//
//	}

	void MakeSingleton () {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void checkGameStatus( int score, int coinScore, int lifeScore ){
		
		if (lifeScore  < 0) {
			
			gameStartedFromMainMenu = false;
			gameRestartAfterPlayerDied = false;

			GameplayController.instance.GameOverShowPanel ( score, coinScore );


		} else {

			this.score = score;
			this.coinScore = coinScore;
			this.lifeScore = lifeScore;

			GameplayController.instance.SetScore ( score );
			GameplayController.instance.setCoinScore( coinScore );
			GameplayController.instance.setLifeScore (lifeScore );

			gameStartedFromMainMenu = false;
			gameRestartAfterPlayerDied = true;

			GameplayController.instance.PlayerDiedRestartTheGame ();
		}
	}
}
