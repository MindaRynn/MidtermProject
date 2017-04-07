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


	void Start () {
//		PlayerPrefs.SetString ("PlayerPos", 0 + "," + 0.7);		
//		PlayerPrefs.SetInt ("data1", 0);
//		PlayerPrefs.SetInt ("data2", 0);
//		PlayerPrefs.SetInt ("data3", 0);
//		PlayerPrefs.SetInt ("data4", 0);
//		PlayerPrefs.SetInt ("data5", 0);
//		PlayerPrefs.SetInt ("moveCam1", 0);
		sound = alertSound.GetComponent<AudioSource> ();
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
		dialogueManager = FindObjectOfType<DialogueManager> ();
		if (textFile != null) {
			dialogueLines = textFile.text.Split ('\n');
		}
	}

	public void playStateOne(){
		sound.Stop ();
		sound = stage1.GetComponent<AudioSource> ();
		sound.Play();
	}

	public void playStateTwo(){
		sound.Stop ();
		sound = stage2.GetComponent<AudioSource> ();
		sound.Play();
	}

	public void playStateThree(){
		sound.Stop ();
		sound = stage3.GetComponent<AudioSource> ();
		sound.Play();
	}

	public void playBoss(){
		sound.Stop ();
		sound = boss.GetComponent<AudioSource> ();
		sound.Play();
	}

	IEnumerator PlaySound(){
		alertSound.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(6.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
