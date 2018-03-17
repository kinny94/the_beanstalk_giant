using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 8f;
	public float maxVelocity = 4f;

	//[SerializeField] // This will show the private variables in the script
	private Rigidbody2D myBody;
	private Animator anim;

	// This is the first function that gets executed when the game is run
	void Awake(){
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	// Use this for initialization
	void Start () {
		
	}

	//Difference between update and FixedUpdate is that update is called every frame per second.
	// Fixed update is going to be called every couple of frames. 
	// Update is called once per frame
	void FixedUpdate () {
		PlayerMoveKeyboard ();
		
	}

	void PlayerMoveKeyboard(){
		float forceX = 0f;
		float vel = Mathf.Abs ( myBody.velocity.x );

		float h = Input.GetAxisRaw ("Horizontal"); //This is gonna return a number, if we press A(-1) and D(1) or Arrow keys

		if (h > 0) {
			// we pressed the right or D key
			if (vel < maxVelocity) {
				forceX = speed;
			}

			Vector3 temp = transform.localScale;
			temp.x = 1.3f;
			transform.localScale = temp;

			anim.SetBool ("Walk", true);
		} else if (h < 0) {
			// we are going to the left side
			if (vel < maxVelocity) {
				forceX = -speed;
			}

			Vector3 temp = transform.localScale;
			temp.x = -1.3f;
			transform.localScale = temp;

			anim.SetBool ("Walk", true);
		} else {
			anim.SetBool ("Walk", false);
		}

		myBody.AddForce (new Vector2 (forceX, 0));
	}
}
