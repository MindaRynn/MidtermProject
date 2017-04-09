using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour {

	public GameObject dialogueBox;
	public Text dialogueText;
	public Text pageCountText;
	public bool isActive;

	public string[] dialogueLines;
	public int currentLine;

	private Vector3 hidingPos;

	private PlayerController player;
	private GameObject doctor,gameController;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		hidingPos = new Vector3(-30.5f, -50.5f);
	}

	// Update is called once per frame
	void Update () {
		
		// Check if the dialogue box is currently active
		if (isActive) {

			// Check if W or the mouse is being pressed, move to the next page
			if ((Input.GetKeyDown (KeyCode.W) || Input.GetMouseButtonUp (0))) {
				currentLine++;
			}

			// Check if Q is being pressed, move to the previous page
			if (Input.GetKeyDown (KeyCode.Q)) {
				previousText ();
			}
		}

		// Check if the dialogue reaches the end text
		if (currentLine >= dialogueLines.Length) {
			HideDialogue ();
		}

		// Set dialgoue texts
		if (isActive) {
			dialogueText.text = dialogueLines [currentLine];
			pageCountText.text = "หน้า: " + (currentLine + 1) + "/" + (dialogueLines.Length);
		}
	}

	// Go to the previous page of the text
	public void previousText() {
		if (currentLine >= 1) {
			currentLine--;
		}
	}

	// Hide the dialogue box
	public void HideDialogue () {
		dialogueBox.SetActive (false);
		isActive = false;
		player.canMove = true;
		player.dialogRunning = false;
		currentLine = 0;
		if (PlayerPrefs.GetInt ("bossChanging") == 1) {
			doctor = GameObject.Find ("Doctor");
			gameController = GameObject.Find ("GameController");
			doctor.GetComponent<Animation> ().Play();
			doctor.gameObject.GetComponentInParent<MaterialController> ().Changing ();
			gameController.gameObject.GetComponentInParent<GameController> ().playBoss ();
			doctor.gameObject.GetComponent<BossController> ().enabled = true;
			PlayerPrefs.SetInt ("bossChanging", 0);
		}
	}

	//	public void ShowBox (string dialogue) {
	//		dialogueBox.SetActive (true);
	//		isActive = true;
	//		dialogueText.text = dialogue;
	//	}

	// Show the dialogue box
	public void ShowDialogue () {
		dialogueBox.SetActive (true);
		isActive = true;
		player.canMove = false;
		player.dialogRunning = true;
	}

}

