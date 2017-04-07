using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	private float alpha;
	private float totalTime;
	private bool fadeIn;
	private bool fadeOut;
	public int fadeSpeed;

	// Use this for initialization
	void Awake () {
		alpha = 0f;
		totalTime = 0f;
		fadeIn = true;
		fadeOut = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			SceneManager.LoadScene (1);
		}
		totalTime += Time.deltaTime * fadeSpeed;
		if (totalTime >= 0.09) {
			alpha += 0.01f;
			totalTime = 0;
		}
		GetComponent<RawImage> ().color = new Color (255, 255, 255, alpha);
	}
}
