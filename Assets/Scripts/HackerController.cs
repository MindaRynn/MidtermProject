using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackerController : MonoBehaviour {


	public GameObject shot;
	public Transform spotSpawn;
	public float speed;
	public float fireRate;
	private float nextFire;
	public GameObject explosion;

	//	public Boundary boundary;
	public Vector3 up = new Vector3(0,1.0f,0);
	public Vector3 down = new Vector3(0,-1.0f,0);
	float lockPos = 0;

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody> ().velocity = movement * speed;
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "eShot") {
			Destroy (other.gameObject);
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
		}
	}

//	void OnTriggerExit (Collider other){
//		if (other.tag == "eShot") {
//			GetComponent<Renderer>().material.color = new Color(1.0F,1.0F, 1.0F, 1.0F);
//			Destroy (other.gameObject);
//			Destroy (gameObject);
//			Instantiate (explosion, transform.position, transform.rotation);
//		}
//	}

	void Update () {
		transform.rotation = Quaternion.Euler(lockPos, transform.rotation.eulerAngles.y, lockPos);
		if (Time.time > nextFire)
		{
			nextFire += fireRate;
			Instantiate(shot, spotSpawn.position, spotSpawn.rotation);
		}

		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0,-angle,0));
	}
}
