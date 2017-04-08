using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3dialog : MonoBehaviour {

	public string dialogue;

	private DialogueManager dialogueManager;

	public TextAsset textFile;

	public string[] dialogueLines;

	public GameObject gameContoller,doctor;
	// Use this for initialization
	void Awake () {
		dialogueManager = FindObjectOfType<DialogueManager> ();
		if (textFile != null) {
			dialogueLines = textFile.text.Split ('\n');
		}
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.name == "Player") {
			//dialogueManager.ShowBox (dialogue);
			PlayerPrefs.SetInt("bossChanging",1);
			if (!dialogueManager.isActive) {
				dialogueManager.dialogueLines = dialogueLines;
				dialogueManager.currentLine = 0;
				dialogueManager.ShowDialogue ();
				gameContoller.gameObject.GetComponentInParent<GameController> ().playStateThree ();
				Destroy (gameObject);
			}
		}
	}
}
