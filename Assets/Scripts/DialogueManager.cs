using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour {

	public GameObject dialogueBox;
	public Text dialogueText;
	public Text pageCountText;
	public bool isActive;
	public Button actionButton;

	public string[] dialogueLines;
	public int currentLine;

	private int touchedCounter;

	private Vector3 hidingPos;

	private PlayerController player;

	// Use this for initialization
	void Start () {
		touchedCounter = 0;
		player = FindObjectOfType<PlayerController> ();
		hidingPos = new Vector3(-30.5f, -50.5f);
	}

	// Update is called once per frame
	void Update () {

		//		if (Input.GetKeyDown (KeyCode.M)) {
		//			player.paused = !player.paused;
		//		}

		// Check if the mouse is being hold (as well as touched)
		if (Input.GetMouseButtonUp (0)) {
			touchedCounter = 0;
		}

		// Check if the dialogue box is currently active
		if (isActive) {

			// Check if the mouse is being pressed (as well as touched)
			if (Input.GetMouseButton (0)) {
				touchedCounter++;
			}

			// Check if the mouse is being hold for 70 frames (a little longer than a second)
			if (touchedCounter >= 70) {
				HideDialogue ();
				touchedCounter = 0;
			}

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
		dialogueText.text = dialogueLines [currentLine];
		pageCountText.text = "หน้า: " + (currentLine + 1) + "/" + (dialogueLines.Length);
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
		actionButton.gameObject.SetActive (true);
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
		actionButton.gameObject.SetActive (false);
	}

}

