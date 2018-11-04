using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	[SerializeField] float ScreenWidthWorldUnits = 16;
	[SerializeField] float MinX = 1;
	[SerializeField] float MaxX = 15;

	//cache
	GameSession gameSession;
	Ball ball;

	// Use this for initialization
	void Start () {
		gameSession = FindObjectOfType<GameSession> ();
		ball = FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		float mouseXposition = Mathf.Clamp (GetXPos(), MinX, MaxX);
		this.transform.position = new Vector3 (mouseXposition, this.transform.position.y);
	}

	/// <summary>
	/// Gets the X position.
	/// </summary>
	/// <returns>The X position.</returns>
	private float GetXPos()
	{
		if(gameSession.IsAutoPlayEnabled())
		{
			return ball.transform.position.x;
		}
		else{
			return (Input.mousePosition.x / Screen.width) * ScreenWidthWorldUnits;
		}
	}
}
