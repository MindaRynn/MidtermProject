using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {
	public GameObject myCamera;
	public string dialogue;
	public GameObject gameController;

	private DialogueManager dialogueManager;

	public TextAsset textFile;

	public string[] dialogueLines;

	// Use this for initialization
	void Start(){
		if (PlayerPrefs.GetInt ("moveCam1") == 1) {
			gameController.gameObject.GetComponentInParent<GameController> ().playStateOne ();
			Destroy (gameObject);
		}
	}
	void Awake () {
		dialogueManager = FindObjectOfType<DialogueManager> ();
		if (textFile != null) {
			dialogueLines = textFile.text.Split ('\n');
		}
	}
		
	void OnTriggerEnter (Collider other){
		if(other.tag == "Player"){
			gameController.gameObject.GetComponentInParent<GameController> ().playStateOne ();
			myCamera.GetComponent<Animation> ().Play();
			if (!dialogueManager.isActive) {
				dialogueManager.dialogueLines = dialogueLines;
				dialogueManager.currentLine = 0;
				dialogueManager.ShowDialogue ();
			}
			Destroy (gameObject);
			PlayerPrefs.SetInt ("moveCam1", 1);
		}
	}
}
