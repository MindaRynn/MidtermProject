using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightController : MonoBehaviour {

	private static bool existed;

	// Use this for initialization
	void Awake () {
		if (!existed) {
			DontDestroyOnLoad (transform.gameObject);
			existed = true;
		}
		else {
			Destroy (gameObject);
		}
		if (SceneManager.GetActiveScene ().name == "MainStage1") {
			Vector3 pos = new Vector3 (0f, 3f, 0f);
			transform.position = pos;
			transform.rotation = Quaternion.Euler (50f, -48.61f, 0f);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
