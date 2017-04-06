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
	private Vector3 moveTo;
	private GameObject player;

	// Use this for initialization
	void Awake () {
		alpha = 1f;
		totalTime = 0f;
		fadeIn = true;
		fadeOut = false;
		player = GameObject.Find ("Player").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (alpha >= 0 && alpha <= 1) {
			if (fadeIn && !fadeOut) {
				FadeInUpdate ();
			}
			else if (!fadeIn && fadeOut) {
				FadeOutUpdate ();
			}
			else if (fadeIn && fadeOut) {
				FadeOutUpdate ();
				if (alpha >= 1f) {
					player.transform.position = moveTo;
					FadeIn ();
				}
			}
			GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
		}
		else if (alpha <= 0) {
			gameObject.SetActive (false);
		}
	}

	private void FadeInUpdate () {
		totalTime += Time.deltaTime * fadeSpeed;
		if (totalTime >= 0.09) {
			alpha -= 0.01f;
			totalTime = 0;
		}
	}

	private void FadeOutUpdate () {
		totalTime += Time.deltaTime * fadeSpeed;
		if (totalTime >= 0.09) {
			alpha += 0.01f;
			totalTime = 0;
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

	public void FadeOutAndIn (Vector3 pos) {
		fadeIn = true;
		fadeOut = true;
		alpha = 0f;
		moveTo = pos;
	}
}
