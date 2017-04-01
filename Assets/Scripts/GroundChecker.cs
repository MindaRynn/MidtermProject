using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour {

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = gameObject.GetComponentInParent<PlayerController> ();
	}

	void OnCollisionEnter (Collision obj) {
		if (obj.gameObject.tag == "Ground") {
			player.jumpCount = 2;
		}
		Debug.Log (obj.gameObject.tag);
	}
}
