using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoxController : MonoBehaviour {
	public GameObject whitecube;

	void OnTriggerEnter (Collider other){
		if (other.tag == "Bolt" || other.tag == "eShot") {
			Destroy (other.gameObject);
		}
	}
}
