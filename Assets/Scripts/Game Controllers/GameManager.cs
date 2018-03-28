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
				GameplayController.instance.setScore (score);
				GameplayController.instance.setCoinScore (coinScore);
				GameplayController.instance.setLifeScore (lifeScore);

				PlayerScript.scoreCount = score;
				PlayerScore.coinScore = coinScore; 
				PlayerScore.lifeScore = lifeScore;
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
}
