using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBallController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision other){
		if (other.collider.tag == "Player") {
			other.gameObject.GetComponentInParent<HealthController> ().Heal (10);
			Destroy (gameObject);
		}
	}
}
