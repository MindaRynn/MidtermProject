using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEnder : MonoBehaviour {

	public GameObject faderObj;
	private Fader fader;

	// Use this for initialization
	void Awake () {
		fader = faderObj.GetComponent<Fader> ();
	}

	void OnTriggerEnter (Collider obj) {
		if (obj.gameObject.tag == "Player") {
			fader.gameObject.SetActive (true);
			fader.FadeOutAndIn (new Vector3 (120, 51, 0));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
