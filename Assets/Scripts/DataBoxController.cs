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

	void Awake() {
		isOpened = false;
		canOpen = false;
		sound = pickUp.GetComponent<AudioSource> ();
		player = GameObject.Find ("Player").gameObject;
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
				Application.LoadLevel (1);
			}
		}
	}
}
