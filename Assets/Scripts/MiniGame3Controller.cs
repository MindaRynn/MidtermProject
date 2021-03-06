﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame3Controller : MonoBehaviour {
	
	public GameObject whiteBox,blackBox;
	public GameObject faderObj;
	private Fader fader;
	public GameObject hacker;
	private bool hasFaded;
	private int cpuNum;

	// Use this for initialization
	void Awake () {
		fader = faderObj.GetComponent<Fader> ();
		fader.gameObject.SetActive (true);
		cpuNum = 1;
		hasFaded = false;
		string maze = "##oo##oo##oo##oo#ooo#o#oo#o##oo#o#o#o##o##oooooo#o#o##o#oo#oo###o#oo#o#o##oo#ooo##o###o#oo#oo#o##o###oo##oo##o##o#oo#oooo###o##oooo###oo#ooo#o###oo##oo#o##oooo##o##oo#o#o#oo#o#o#oooo#oo##o#ooo#o##oo######o##o#oo#ooooo#ooo#o#o";
		int check = 0;
		for (int i = 0; i < 15; i++) {
			for (int j = 0; j < 15; j++) {
				if (maze[check] == 'o') {
					Instantiate(blackBox, new Vector3((float)((-20.5)+(3*j)),0.5f,(-10.5f)+(float)(3*i)), transform.rotation);
					check++;
				} 
				else {
					Instantiate(whiteBox, new Vector3((float)((-20.5)+(3*j)),0.5f,(-10.5f)+(float)(3*i)), transform.rotation);
					check++;
				}
			}
		}
	}

	void StageCompleted () {
		PlayerPrefs.SetInt ("data"+PlayerPrefs.GetInt("numHacking"), 1);
		PlayerPrefs.SetInt ("numHacking", 0);
		fader.gameObject.SetActive (true);
		fader.FadeOutAndLoad ("MainStage1");
	}

	void Update(){
		if (hacker.gameObject.GetComponentInParent<HackerCounter>().getCpuDestroyed() >= cpuNum && !hasFaded) {
			hasFaded = true;
			StageCompleted ();
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			StageCompleted ();
		}
	}
}
