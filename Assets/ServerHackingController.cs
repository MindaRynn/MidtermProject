using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerHackingController : MonoBehaviour {

	bool isOpened, canOpen;
	public GameObject noticeSign;
	public int numData;
	private GameObject player;
	public GameObject faderObj;
	private Fader fader;


	// Use this for initialization
	void Awake () {
		isOpened = false;
		canOpen = false;
		fader = faderObj.GetComponent<Fader> ();
		player = GameObject.Find ("Player").gameObject;
		Debug.Log ("test:"+PlayerPrefs.GetInt ("data"+numData));
		if (PlayerPrefs.GetInt ("data"+numData) == 1) {
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

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (!isOpened && canOpen) {
				isOpened = true;
				PlayerPrefs.SetString ("PlayerPos", player.transform.position.x + "," + player.transform.position.y);
				PlayerPrefs.SetInt ("numHacking", numData);
				fader.gameObject.SetActive (true);
				fader.FadeOutAndLoad ("MiniGame3");
			}
		}
	}

}
