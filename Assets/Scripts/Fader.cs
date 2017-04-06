using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

	private float alpha;
	private float totalTime;
	private bool fadeIn;
	private bool fadeOut;
	public int fadeSpeed;

	// Use this for initialization
	void Awake () {
		alpha = 1f;
		totalTime = 0f;
		fadeIn = true;
		fadeOut = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (alpha >= 0 && alpha <= 1) {
			if (fadeIn && !fadeOut) {
				totalTime += Time.deltaTime * fadeSpeed;
				if (totalTime >= 0.09) {
					alpha -= 0.01f;
					totalTime = 0;
				}
				GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
			} else if (!fadeIn && fadeOut) {
				totalTime += Time.deltaTime * fadeSpeed;
				if (totalTime >= 0.09) {
					alpha += 0.01f;
					totalTime = 0;
				}
				GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
			}
		}
		else if (alpha <= 0) {
			gameObject.SetActive (false);
		}
	}

	public void FadeIn () {
		fadeIn = true;
		fadeOut = false;
		alpha = 1f;
	}

	public void FadeOut () {
		fadeIn = false;
		fadeOut = true;
		alpha = 0f;
	}
}
