using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubistMovement : MonoBehaviour {
	private bool activated;
	private KeyCode upKey = KeyCode.I;
	private KeyCode downKey = KeyCode.K;
	private KeyCode leftKey = KeyCode.J;
	private KeyCode rightKey = KeyCode.L;
	// Use this for initialization
	void Start () {
		activated = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (activated == true) {
			//gameObject.transform.position = Input.mousePosition;
			Move (Vector3.up, upKey);
			Move (Vector3.down, downKey);
			Move (Vector3.left, leftKey);
			Move (Vector3.right, rightKey);
		}
	}

	void OnMouseDown(){
		if (activated == false) {
			activated = true;
		} else {
			activated = false;
		}
	}

	void Move(Vector3 dir, KeyCode key){
		if (Input.GetKey (key)) {
			transform.Translate (dir * 20 * Time.deltaTime);
		}
	}
}
