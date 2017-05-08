using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class automaticMondrian : MonoBehaviour {
	private Vector3 spawnPos;
	private Vector3[] blackBarScale;
	private bool ortho;
	//public GameObject[] cubes;
	private Slider redMondrianess;
	private Slider blueMondrianess;
	private Slider yellowMondrianess;
	private Slider blackMondrianess;
	private Slider fieldOfViewSize;

	private Slider redScale;
	private Slider blueScale;
	private Slider yellowScale;

	private Camera mainCamera;
    private Camera bulletCamera;
    private Vector3 muzzle;

	public GameObject redCubes;
	public GameObject blueCubes;
	public GameObject yellowCubes;
	public GameObject blackCubes;
    public GameObject bullet;
	//public float orthoCameraSize = 50;

	// Use this for initialization
	void Start () {
		blackBarScale = new Vector3[3];
		redMondrianess = GameObject.Find ("Red Mondrianess").GetComponent<Slider>();
		blueMondrianess = GameObject.Find ("Blue Mondrianess").GetComponent<Slider>();
		yellowMondrianess = GameObject.Find ("Yellow Mondrianess").GetComponent<Slider>();
		blackMondrianess = GameObject.Find ("Black Mondrianess").GetComponent<Slider>();

		redScale = GameObject.Find ("Red Cubousity").GetComponent<Slider> ();
		blueScale = GameObject.Find ("Blue Cubousity").GetComponent<Slider> ();
		yellowScale = GameObject.Find ("Yellow Cubousity").GetComponent<Slider> ();

		fieldOfViewSize = GameObject.Find ("Camera angle").GetComponent<Slider> ();
		mainCamera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		ortho = true;
        muzzle = GameObject.Find("Main Camera").transform.position;

    }
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			PaintRed ();
			PaintBlue ();
			PaintYellow ();
			BlackBar ();
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			mainCamera.orthographic = !mainCamera.orthographic;

		
		}

		/*if (Input.GetKeyDown (KeyCode.V) && ortho == true) {
			mainCamera.orthographic = false;

			ortho = false;
		}*/
		mainCamera.fieldOfView = fieldOfViewSize.value;
		mainCamera.orthographicSize = fieldOfViewSize.value;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject projectile = Instantiate(bullet, muzzle, Quaternion.identity) as GameObject;
            bulletCamera = projectile.GetComponent<Camera>();
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            bulletCamera.orthographic = !mainCamera.orthographic;
            bulletCamera.fieldOfView = fieldOfViewSize.value;
            bulletCamera.orthographicSize = fieldOfViewSize.value;
            rb.velocity = new Vector3(0, 0, 50f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("canvas1", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("canvas2", LoadSceneMode.Single);
        }

	}

	void PaintRed () {
		for (int i = 0; i < redMondrianess.value; i++) {
			spawnPos = new Vector3 (Random.Range (0, 100), Random.Range (0, 100), Random.Range (0, 100));
			//Instantiate (cubes [Random.Range (0, cubes.Length)], spawnPos, Quaternion.identity);
			GameObject redSquares = Instantiate (redCubes, spawnPos, Quaternion.identity);
			redSquares.transform.localScale = new Vector3 (Random.Range (1, redScale.value), Random.Range (1, redScale.value), Random.Range (1, redScale.value));
			redSquares.transform.parent = GameObject.Find ("Painting").transform;
		}
	}

	void PaintBlue () {
		for (int i = 0; i < blueMondrianess.value; i++) {
			spawnPos = new Vector3 (Random.Range (0, 100), Random.Range (0, 100), Random.Range (0, 100));
			//Instantiate (cubes [Random.Range (0, cubes.Length)], spawnPos, Quaternion.identity);
			GameObject blueSquares = Instantiate (blueCubes, spawnPos, Quaternion.identity);
			blueSquares.transform.localScale = new Vector3 (Random.Range (1, blueScale.value), Random.Range (1, blueScale.value), Random.Range (1, blueScale.value));
			blueSquares.transform.parent = GameObject.Find ("Painting").transform;
		}
	}

	void PaintYellow () {
		for (int i = 0; i < yellowMondrianess.value; i++) {
			spawnPos = new Vector3 (Random.Range (0, 100), Random.Range (0, 100), Random.Range (0, 100));
			//Instantiate (cubes [Random.Range (0, cubes.Length)], spawnPos, Quaternion.identity);
			GameObject yellowSquares = Instantiate (yellowCubes, spawnPos, Quaternion.identity);
			yellowSquares.transform.localScale = new Vector3 (Random.Range (1, yellowScale.value), Random.Range (1, yellowScale.value), Random.Range (1, yellowScale.value));
			yellowSquares.transform.parent = GameObject.Find ("Painting").transform;
		}
	}

	void BlackBar() {
		for (int i = 0; i < blackMondrianess.value; i++) {
			blackBarScale [0] = new Vector3 (1, 1, Random.Range (1, 20));
			blackBarScale [1] = new Vector3 (Random.Range (1, 20), 1, 1);
			blackBarScale [2] = new Vector3 (1, Random.Range (1, 20), 1);
			spawnPos = new Vector3 (Random.Range (0, 100), Random.Range (0, 100), Random.Range (0, 100));

			GameObject blackBars = Instantiate (blackCubes, spawnPos, Quaternion.identity);
			blackBars.transform.localScale = blackBarScale [Random.Range (0, 2)];
			blackBars.transform.parent = GameObject.Find ("Painting").transform;
		}
	}
}

