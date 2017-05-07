using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class spinningMondrian : MonoBehaviour {
	private Vector3 spinToRight;
	private Vector3 spinToLeft;
	private Vector3 spinUp;
	private Vector3 spinDown;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.D)) {
			RotateRight ();
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			RotateLeft ();
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			RotateUp ();
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			RotateDown ();
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			ResetCanvas ();
		}
	}

	void RotateRight () {
		spinToRight = gameObject.transform.rotation.eulerAngles + new Vector3 (0, -90, 0);
		gameObject.transform.DORotate (spinToRight, 2, RotateMode.FastBeyond360);
	}

	void RotateLeft () {
		spinToLeft = gameObject.transform.rotation.eulerAngles + new Vector3 (0, 90, 0);
		gameObject.transform.DORotate (spinToLeft, 2, RotateMode.FastBeyond360);
	}

	void RotateUp () {
		spinUp = gameObject.transform.rotation.eulerAngles + new Vector3 (90, 0, 0);
		gameObject.transform.DORotate (spinUp, 2, RotateMode.FastBeyond360);
	}

	void RotateDown() {
		spinDown = gameObject.transform.rotation.eulerAngles + new Vector3 (-90, 0, 0);
		gameObject.transform.DORotate (spinDown, 2, RotateMode.FastBeyond360);
	}

	void ResetCanvas() {
		foreach (Transform child in transform) {
			child.DOScale (new Vector3 (0, 0, 0), 1);
			Destroy (child.gameObject, 1.2f);
		}
	}
}
