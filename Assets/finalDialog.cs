using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalDialog : MonoBehaviour {

	public string dialogue;

	private DialogueManager dialogueManager;

	public TextAsset textFile;

	public string[] dialogueLines;

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
		if (other.gameObject.name == "Player" && PlayerPrefs.GetInt("isDoctorDied")==1) {
			//dialogueManager.ShowBox (dialogue);
			if (!dialogueManager.isActive) {
				dialogueManager.dialogueLines = dialogueLines;
				dialogueManager.currentLine = 0;
				dialogueManager.ShowDialogue ();
				Destroy (gameObject);
			}
		}
	}
}
