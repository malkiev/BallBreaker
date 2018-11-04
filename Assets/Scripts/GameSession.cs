using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

	//config
	[Range(0, 10)]
	[SerializeField] float gameSpeed = 0.7f;
	[SerializeField] int scorePerBlockDestroyed = 83;
	[SerializeField] Text textScore = null;
	[SerializeField] bool isAutoPlayEnabled = false;

	//state
	[SerializeField] int currentScore=0;

	void Awake()
	{
		int gameStatusCount = FindObjectsOfType<GameSession> ().Length;
		if (gameStatusCount > 1) {
			Destroy (gameObject);
		} else {
			DontDestroyOnLoad (gameObject);
		}
	}

	void Start(){
		textScore.text = currentScore.ToString();
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
		if(textScore != null)
		textScore.text = currentScore.ToString();
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
}
