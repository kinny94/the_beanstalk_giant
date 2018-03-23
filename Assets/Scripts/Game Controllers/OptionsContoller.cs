using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsContoller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void goToMainMenu(){
		Application.LoadLevel ("MainMenu");
	}
}
