using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Ender : MonoBehaviour {

	public GameObject faderObj,liftGroup;
	private Fader fader;
	private Vector3 pos;
	public float x, y, z;
	// Use this for initialization
	void Awake () {
		fader = faderObj.GetComponent<Fader> ();
		pos = new Vector3 (x, y, z);
	}

	void OnTriggerEnter (Collider obj) {
		if (obj.gameObject.tag == "Player") {
			liftGroup.gameObject.GetComponentInParent<LiftMover> ().ActiveLift ();
			fader.gameObject.SetActive (true);
			fader.FadeOutAndIn (pos);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
