using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
	//config
	[SerializeField] AudioClip breakingAudioClip = null;
	[SerializeField] GameObject blockSparklesVFX = null;
	[SerializeField] Sprite [] hitSprites = null;

	[SerializeField] int timesHit = 0;

	int maxHits = 0;
	LevelManager levelManager;
	GameSession gameStatus;

	private void Start()
	{
		//Initialise
		levelManager = FindObjectOfType<LevelManager> ();
		gameStatus = FindObjectOfType<GameSession> ();

		maxHits = hitSprites.Length + 1; 
		CountBreakableBlocks ();
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (tag == "Breakable") {
			timesHit++;
			if (timesHit >= maxHits) {
				DestroyBlock ();
			} else {
				ShowNextHitSprite ();
			}
		}
	}

	void ShowNextHitSprite()
	{
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex] != null)
		{
			GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
		else
		{
				Debug.LogError("Block sprite is missing from array: " + gameObject.name);
		}
		
	}

	void CountBreakableBlocks ()
	{
		if (tag == "Breakable") {
			levelManager.CountBreakableBlocks ();
		}
	}

	private void DestroyBlock()
	{
		levelManager.BlockDestroyed ();
		gameStatus.AddToScore ();
		AudioSource.PlayClipAtPoint (breakingAudioClip, Camera.main.transform.position);
		Destroy (gameObject);
		TriggerSparkles ();
	}

	private void TriggerSparkles()
	{
		GameObject sparkles = Instantiate (blockSparklesVFX, transform.position, transform.rotation);
		Destroy (sparkles, 1f);
	}
}
