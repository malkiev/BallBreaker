using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

	//config
	[Range(0, 10)]
	[SerializeField] float gameSpeed = 0.7f;
	[SerializeField] int scorePerBlockDestroyed = 83;
	[SerializeField] bool isAutoPlayEnabled = false;

	//state
	[SerializeField] int currentScore;

	private static GameSession _instance;
	public static GameSession Instance {
		get {
			if (_instance == null) {
				Debug.LogWarning ("Attempted to access GameSession instance with no available instance.");//This should not happen unless I omit the script from a scene
			}

			return _instance;
		}
	}

	void Awake()
	{
		if (Instance != null && Instance != this) {
			Destroy (gameObject);
			print ("Duplicate GameSession self-destructing!");
		} else {
			_instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void Start(){
		
	}

	// Update is called once per frame
	void Update () {
		Time.timeScale = gameSpeed;
	}

	/// <summary>
	/// Adds to score.
	/// </summary>
	public void AddToScore()
	{
		currentScore += scorePerBlockDestroyed;
		print (currentScore);
	}

	public void Destroy()
	{
		Destroy (gameObject);
	}

	/// <summary>
	/// Determines whether this instance is auto play enabled.
	/// </summary>
	/// <returns><c>true</c> if this instance is auto play enabled; otherwise, <c>false</c>.</returns>
	public bool IsAutoPlayEnabled()
	{
		return isAutoPlayEnabled;
	}

	public float GetScore()
	{
		return currentScore;
	}
}
