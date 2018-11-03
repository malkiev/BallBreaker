using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	//config params
	[SerializeField] Paddle paddle1;
	[SerializeField] float xPush = 2f;
	[SerializeField] float yPush = 10f;
	[SerializeField] AudioClip[] ballSounds;


	//state
	Vector2 paddleToBallVector;
	bool ballLaunched;

	//cached
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		paddleToBallVector = transform.position - paddle1.transform.position;
		ballLaunched = false;
		audioSource = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!ballLaunched) {
			LockBallToPaddle ();
			LaunchOnMouseClick ();
		}
	}

	void LockBallToPaddle ()
	{
		Vector2 paddlePos = new Vector2 (paddle1.transform.position.x, paddle1.transform.position.y);
		transform.position = paddlePos + paddleToBallVector;
	}

	void LaunchOnMouseClick()
	{
		if (Input.GetMouseButtonDown (0)) {
			ballLaunched = true;
			Rigidbody2D rigidBody = transform.GetComponent<Rigidbody2D> ();
			rigidBody.velocity = new Vector2 (xPush, yPush);
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (ballLaunched) {
			AudioClip audioClip = ballSounds [Random.Range (0, ballSounds.Length)];
			audioSource.PlayOneShot (audioClip);
		}
	}
}
