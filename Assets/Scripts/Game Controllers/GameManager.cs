using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[HideInInspector]
	public bool gameStartedFromMainMenu, gameRestartAfterPlayerDied;

	[HideInInspector]
	public int score, coinScore, lifeScore;

	void Awake () {
		MakeSingleton ();
	}

	void OnLevelWasLoaded(){
		
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

	void MakeSingleton () {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void checkGameStatus( int score, int coinscore, int lifescore ){
		
		if (lifescore < 0) {
			
			gameStartedFromMainMenu = false;
			gameRestartAfterPlayerDied = false;

			GameplayController.instance.GameOverShowPanel ( score, coinscore );


		} else {

			this.score = score;
			this.coinScore = coinscore;
			this.lifeScore = lifescore;

			GameplayController.instance.SetScore ( score );
			GameplayController.instance.setCoinScore( coinscore );
			GameplayController.instance.setLifeScore (lifescore);

			gameStartedFromMainMenu = false;
			gameRestartAfterPlayerDied = true;


		}
	}
}
