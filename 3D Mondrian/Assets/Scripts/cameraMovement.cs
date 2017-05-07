using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {
	public float speed = 1f;
	private KeyCode upKey = KeyCode.UpArrow;
	private KeyCode downKey = KeyCode.DownArrow;
	private KeyCode leftKey = KeyCode.LeftArrow;
	private KeyCode rightKey = KeyCode.RightArrow;
	private KeyCode forwardKey = KeyCode.RightBracket;
	private KeyCode backwardKey = KeyCode.LeftBracket;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move (Vector3.up, upKey);
		Move (Vector3.down, downKey);
		Move (Vector3.left, leftKey);
		Move (Vector3.right, rightKey);
		Move (Vector3.forward, forwardKey);
		Move (Vector3.back, backwardKey);
	}

	void Move(Vector3 dir, KeyCode key){
		if (Input.GetKey (key)) {
			transform.Translate (dir * speed * Time.deltaTime);
		}
	}
}
