﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftHackingController : MonoBehaviour {
	bool isOpened, canOpen;
	public GameObject noticeSign;
	public GameObject arrow;
	public int numData;
	private GameObject player;
	public GameObject faderObj;
	private Fader fader;

	public string dialogue;

	private DialogueManager dialogueManager;

	public TextAsset textFile;

	public string[] dialogueLines;

	private bool message;

	// Use this for initialization
	void Awake () {
		dialogueManager = FindObjectOfType<DialogueManager> ();
		if (textFile != null) {
			dialogueLines = textFile.text.Split ('\n');
		}
		message = false;
		isOpened = false;
		canOpen = false;
		fader = faderObj.GetComponent<Fader> ();
		player = GameObject.Find ("Player").gameObject;
		Debug.Log ("test:"+PlayerPrefs.GetInt ("data"+numData));
		if (PlayerPrefs.GetInt ("data"+numData) == 1) {
			arrow.GetComponent<Renderer> ().enabled = false;
			isOpened = true;
			Destroy (arrow);
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player" && !isOpened ) {
			noticeSign.GetComponent<Renderer>().enabled = true;
			canOpen = true;
			if (!message) {
				if (!dialogueManager.isActive) {
					dialogueManager.dialogueLines = dialogueLines;
					dialogueManager.currentLine = 0;
					dialogueManager.ShowDialogue ();
					message = true;
				}
			}
		}
	}
	void OnTriggerExit (Collider other){
		if (other.tag == "Player" ) {
			noticeSign.GetComponent<Renderer>().enabled = false;
			canOpen = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (!isOpened && canOpen) {
				isOpened = true;
				arrow.GetComponent<Renderer>().enabled = false;
				PlayerPrefs.SetString ("PlayerPos", player.transform.position.x + "," + player.transform.position.y);
				PlayerPrefs.SetInt ("numHacking", numData);
				fader.gameObject.SetActive (true);
				fader.FadeOutAndLoad ("MiniGame4");
			}
		}
	}


}
