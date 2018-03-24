using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreController : MonoBehaviour {

	private GameplayController gc;
	// Use this for initialization
	void Start () {
		
	}

	public void goBackToMainMenu(){
		Application.LoadLevel ("MainMenu");
	}
}
