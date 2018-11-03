using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	[SerializeField] AudioClip breakingAudioClip;

	LevelManager levelManager;

	private void Start()
	{
		levelManager = FindObjectOfType<LevelManager> ();
		levelManager.CountBreakableBlocks ();
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		levelManager.BlockDestroyed ();
		AudioSource.PlayClipAtPoint (breakingAudioClip, Camera.main.transform.position);
		Destroy (gameObject);
	}
}
