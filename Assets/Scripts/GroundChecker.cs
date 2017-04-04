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
		Debug.Log (obj.gameObject.tag);
		if (obj.gameObject.tag == "Ground" || obj.gameObject.tag == "Lift") {
			player.jumpCount = 2;
		}
	}
}
