using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	//parameters
	[SerializeField] int breakableBlocks;

	//cached
	SceneLoader sceneLoader;

	public void CountBreakableBlocks()
	{
		breakableBlocks++;	
	}

	public void BlockDestroyed(){
		breakableBlocks--;
		if (breakableBlocks <= 0) {
			sceneLoader.LoadNextScene ();
		}
	}

	// Use this for initialization
	void Start () {
		sceneLoader = FindObjectOfType<SceneLoader> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
