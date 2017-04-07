using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGame2Controller : MonoBehaviour {
	public GameObject whiteBox,blackBox;
	private int cpuNum;
	public GameObject hacker;
	public GameObject faderObj;
	private Fader fader;
	private bool hasFaded;
	// Use this for initialization

	void Awake () {
		fader = faderObj.GetComponent<Fader> ();
		fader.gameObject.SetActive (true);
		cpuNum = 1;
		hasFaded = false;
		string[] maze = new string[10];
		maze [0] = "ooo##ooooo#oooo#o#oooo#oo#oo#o#oo#ooo#ooooo##oo#oooo#oo#o#oo";
		maze [1] = "ooo##ooooo#oo#o##ooooo##o#oo#ooooo#oo#oo#o##oooo#o##o##oo##o";
		maze [2] = "oo#ooooo##o##o##o##o##ooo#oo#o#oooo#o#oo#oo#oooo##o#oo#o##o#";
		maze [3] = "oooo#oo#oo#oo#oo#o##ooooo#oo#oo#oo#ooo##o##o##o##ooo#oo#o#oo";
		maze [4] = "o##oo##o##o##ooo#o#oooo#o#ooo##ooo#ooooo##o#ooo##o##o##o##o#";
		maze [5] = "oo#o##oooo#o#oooo#o#oo#oo#oo#ooo##ooo#o#oo#ooo#o#oo#o##ooo#o";
		maze [6] = "oooo#o#oooo#o##oooo#o##ooooo#oo#oo#oo#ooo##o##ooo#o#oo#o##o#";
		maze [7] = "oo#ooo#o##o#oo#ooo##oo#oo#o#oo#o#oo#o#oooo##o#oo#o##o#oo#o#o";
		maze [8] = "o#ooooo#o#oooo#o#ooo#oooo#oo#oo#oo#oo#oo#o#oo#o##oo##oo#oo#o";
		maze [9] = "o#oo#oo#oo#oo#oo#ooo##o##ooo#o#oooo#o#ooo##o##ooo#ooooo##oo#";

		int check = 0;
		int numMaze = Random.Range (0, 9);
		for (int i = 0; i < 20; i++) {
			for (int j = 0; j < 3; j++) {
				if (maze[numMaze][check] == 'o') {
					Instantiate(blackBox, new Vector3((float)((j*3)-3),0.5f,(-28f)+(float)(3*i)), transform.rotation);
					check++;
				} 
				else {
					Instantiate(whiteBox, new Vector3((float)((j*3)-3),0.5f,(-28f)+(float)(3*i)), transform.rotation);
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
	}
}
