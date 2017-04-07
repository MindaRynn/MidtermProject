using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {

	private HealthController player;
	public string direction;
	public string shooter;

	// Use this for initialization
	void Awake () {
		player = (HealthController) GameObject.Find ("Player").GetComponent ("HealthController");
	}

	// Update is called once per frame
	void Update () {
		if (direction == "Left") {
			Vector3 movementPos = new Vector3 (transform.position.x - 3, transform.position.y, transform.position.z);
			transform.position = Vector3.MoveTowards (transform.position, movementPos, 8 * Time.deltaTime);
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, 180, transform.eulerAngles.z);
		}
		else if (direction == "Right") {
			Vector3 movementPos = new Vector3 (transform.position.x + 3, transform.position.y, transform.position.z);
			transform.position = Vector3.MoveTowards (transform.position, movementPos, 8 * Time.deltaTime);
		}
	}

	void OnTriggerEnter (Collider obj) {
		if (shooter == "Player") {
			if (obj.gameObject.tag == "Bot") {
				obj.gameObject.GetComponentInParent<HealthController> ().Damage (10);
				if (obj.gameObject.GetComponentInParent<HealthController> ().GetHP () <= 0) {
					Destroy (obj.gameObject);
				}
			}
		}
		else if (shooter == "Bot") {
			if (obj.gameObject.tag == "Player") {
				obj.gameObject.GetComponentInParent<HealthController> ().Damage (10);
			}
		}
		Destroy (this.gameObject);
	}
}
