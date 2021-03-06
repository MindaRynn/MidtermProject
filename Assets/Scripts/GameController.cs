﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour {
	public GameObject alertSound,stage1,stage2,stage3,boss;
	AudioSource sound;
	public string dialogue;

	private DialogueManager dialogueManager;

	public TextAsset textFile;

	public string[] dialogueLines;

	public GameObject wall1;

	void Start () {
		if (PlayerPrefs.GetInt ("data5") == 0) {
			sound.Play();
			if (!dialogueManager.isActive) {
				dialogueManager.dialogueLines = dialogueLines;
				dialogueManager.currentLine = 0;
				dialogueManager.ShowDialogue ();
			}
		}
	}

	void Awake () {
		sound = alertSound.GetComponent<AudioSource> ();
		dialogueManager = FindObjectOfType<DialogueManager> ();
		if (textFile != null) {
			dialogueLines = textFile.text.Split ('\n');
		}
	}

	public void playStateOne(){
		if (sound.isPlaying) {
			sound.Stop ();
		}
		sound = stage1.GetComponent<AudioSource> ();
		sound.Play();
	}

	public void playStateTwo(){
		if (sound.isPlaying) {
			sound.Stop ();
		}
		sound = stage2.GetComponent<AudioSource> ();
		sound.Play();
	}

	public void playStateThree(){
		if (sound.isPlaying) {
			sound.Stop ();
		}
		sound = stage3.GetComponent<AudioSource> ();
		sound.Play();
	}

	public void playBoss(){
		if (sound.isPlaying) {
			sound.Stop ();
		}
		sound = boss.GetComponent<AudioSource> ();
		sound.Play();
	}

	IEnumerator PlaySound(){
		alertSound.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(6.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			PlayerPrefs.SetInt ("isDoctorDied", 1);
			Destroy (GameObject.Find ("Doctor"));
			playStateOne ();
		}
	}
}
