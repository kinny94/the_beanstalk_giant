using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void goBackToMainMenu(){
		Application.LoadLevel ("MainMenu");
	}
}
