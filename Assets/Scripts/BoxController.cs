﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {
	bool isOpened, canOpen;
	public GameObject noticeSign;
	public GameObject arrow;
	public GameObject player;
	public GameObject pickUp;
	AudioSource sound;
	void Start() {
		isOpened = false;
		canOpen = false;
		sound = pickUp.GetComponent<AudioSource> ();
	}
	void OnTriggerEnter (Collider other){
		if (other.tag == "Player" && !isOpened ) {
			noticeSign.GetComponent<Renderer>().enabled = true;
			canOpen = true;
		}
	}
	void OnTriggerExit (Collider other){
		if (other.tag == "Player" ) {
			noticeSign.GetComponent<Renderer>().enabled = false;
			canOpen = false;
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (!isOpened && canOpen) {
				Debug.Log ("Opening Box");
				isOpened = true;
				arrow.GetComponent<Renderer>().enabled = false;
				sound.Play ();
				player.gameObject.GetComponentInParent<HealthController> ().Heal (20);
			}
		}
	}
}
