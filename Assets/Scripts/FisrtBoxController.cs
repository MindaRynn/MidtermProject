using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisrtBoxController : MonoBehaviour {
	bool isOpened, canOpen;
	public GameObject noticeSign,arrow,player,lockSign,wall;
	public AudioClip pickUp;

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

	public int x;

	void Start() {
		isOpened = false;
		canOpen = false;
		if (PlayerPrefs.GetInt ("data5") == 1) {
			arrow.GetComponent<Renderer> ().enabled = false;
			isOpened = true;
			DestroyDoor ();
		}
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
				AudioSource.PlayClipAtPoint(pickUp, transform.position,1.0f);
				DestroyDoor ();
				if (!dialogueManager.isActive) {
					dialogueManager.dialogueLines = dialogueLines;
					dialogueManager.currentLine = 0;
					dialogueManager.ShowDialogue ();
				}
				PlayerPrefs.SetInt ("data5", 1);
			}
		}
	}

	void DestroyDoor(){
		Destroy (lockSign);
		Destroy (wall);
	}
}
