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
	public int numCam;
	public AnimationClip anim;

	// Use this for initialization
	void Start(){
		myCamera.GetComponent<Animation> ().AddClip (anim, "move"+numCam);
		if (PlayerPrefs.GetInt ("moveCam"+numCam) == 1) {
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
			if (numCam == 1) {
				gameController.gameObject.GetComponentInParent<GameController> ().playStateOne ();
			}
			myCamera.GetComponent<Animation> ().Play("move"+numCam);
			if (!dialogueManager.isActive) {
				dialogueManager.dialogueLines = dialogueLines;
				dialogueManager.currentLine = 0;
				dialogueManager.ShowDialogue ();
			}
			PlayerPrefs.SetInt ("moveCam"+numCam, 1);
			Destroy (gameObject);
		}
	}
}
