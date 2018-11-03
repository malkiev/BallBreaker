using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	[SerializeField] float ScreenWidthWorldUnits = 16;
	[SerializeField] float MinX = 1;
	[SerializeField] float MaxX = 15;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float mouseXposition = Mathf.Clamp ((Input.mousePosition.x / Screen.width) * ScreenWidthWorldUnits, MinX, MaxX);
		this.transform.position = new Vector3 (mouseXposition, this.transform.position.y);
	}
}
