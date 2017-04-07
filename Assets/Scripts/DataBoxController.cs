using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBoxController : MonoBehaviour {
	bool isOpened, canOpen;
	public GameObject noticeSign;
	public GameObject arrow;
	public GameObject pickUp;
	AudioSource sound;
	private GameObject player;
	public int numData;
	public GameObject faderObj;
	private Fader fader;

	void Awake() {
		fader = faderObj.GetComponent<Fader> ();
		isOpened = false;
		canOpen = false;
		sound = pickUp.GetComponent<AudioSource> ();
		player = GameObject.Find ("Player").gameObject;
		if (PlayerPrefs.GetInt ("data"+numData) == 1) {
			arrow.GetComponent<Renderer> ().enabled = false;
			isOpened = true;
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
				isOpened = true;
				arrow.GetComponent<Renderer>().enabled = false;
				PlayerPrefs.SetString ("PlayerPos", player.transform.position.x + "," + player.transform.position.y);
				PlayerPrefs.SetInt ("numHacking", numData);
				Application.LoadLevel (2);
				fader.gameObject.SetActive (true);
				fader.FadeOutAndLoad ("MiniGame1");
			}
		}
	}
}
