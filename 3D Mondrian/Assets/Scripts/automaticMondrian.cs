using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class automaticMondrian : MonoBehaviour {
	private Vector3 spawnPos;
	public GameObject[] cubes;
	public int mondrianess = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			Paint ();
		}
	}

	void Paint () {
		for (int i = 0; i < mondrianess; i++) {
			spawnPos = new Vector3 (Random.Range (0, 100), Random.Range (0, 100), Random.Range (0, 100));
			Instantiate (cubes [Random.Range (0, cubes.Length)], spawnPos, Quaternion.identity);
		}
	}
}
