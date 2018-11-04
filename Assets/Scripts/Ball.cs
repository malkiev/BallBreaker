using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	//config params
	[SerializeField] Paddle paddle1 = null;
	[SerializeField] float xPush = 2f;
	[SerializeField] float yPush = 10f;
	[SerializeField] AudioClip[] ballSounds = null;
	[SerializeField] float randomPush = 0.2f;

	//state
	Vector2 paddleToBallVector;
	bool ballLaunched = false;

	//cached
	AudioSource audioSource;
	Rigidbody2D rigidBody2D;

	// Use this for initialization
	void Start () {
		paddleToBallVector = transform.position - paddle1.transform.position;

		audioSource = this.GetComponent<AudioSource> ();
		rigidBody2D = this.GetComponent<Rigidbody2D> ();
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

			rigidBody2D.velocity += new Vector2 (Random.Range (-randomPush, randomPush), Random.Range (-randomPush, randomPush));
		}
	}
}
