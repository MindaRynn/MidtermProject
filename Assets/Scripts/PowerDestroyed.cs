using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDestroyed : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		if (other.tag == "Bolt") {
			Destroy (gameObject);
		}
	}
}
