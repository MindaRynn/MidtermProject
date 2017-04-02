using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class HackerController : MonoBehaviour {


	public GameObject shot;
	public Transform spotSpawn;
	public float speed;
	public float fireRate;
	private float nextFire;
	public Boundary boundary;

	//	public Boundary boundary;
	public Vector3 up = new Vector3(0,1.0f,0);
	public Vector3 down = new Vector3(0,-1.0f,0);
	float lockPos = 0;

	void Start () {
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody> ().velocity = movement * speed;
		transform.position = new Vector3 (
			Mathf.Clamp(GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax),
			1.0f,
			Mathf.Clamp(GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax)
		);
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "eShot") {
			GetComponent<Renderer>().material.color = new Color(0.03F,0.03F, 0.03F, 1.0F);
		}
	}

	void OnTriggerExit (Collider other){
		if (other.tag == "eShot") {
			GetComponent<Renderer>().material.color = new Color(1.0F,1.0F, 1.0F, 1.0F);
			Destroy (other.gameObject);
		}
	}

	void Update () {
		transform.rotation = Quaternion.Euler(lockPos, transform.rotation.eulerAngles.y, lockPos);
		if (Time.time > nextFire)
		{
			nextFire += fireRate;
			Instantiate(shot, spotSpawn.position, spotSpawn.rotation);
		}

		if (Input.GetKey (KeyCode.W))
		{
			float angle = transform.eulerAngles.y - 0.0f;
			if (Mathf.Abs (angle) >= 270) {
				transform.Rotate (up);
			} else if (Mathf.Abs(angle) <= 90) {
				if (angle < 0) {
					transform.Rotate (up);
				} else {
					transform.Rotate (down);
				}
			} else {
				if (transform.eulerAngles.y >= 181) {
					transform.Rotate (up);
				} else if (transform.eulerAngles.y <= 180) {
					transform.Rotate (down);
				}
			}
		}

		if (Input.GetKey (KeyCode.A))
		{
			float angle = transform.eulerAngles.y - 270.0f;
			if (Mathf.Abs (angle) == 270) {
				transform.Rotate (down);
			} else if (Mathf.Abs(angle) <= 90) {
				if (angle < 0) {
					transform.Rotate (up);
				} else {
					transform.Rotate (down);
				}
			} else {
				if (transform.eulerAngles.y <= 90) {
					transform.Rotate (down);
				} else if (transform.eulerAngles.y >= 91) {
					transform.Rotate (up);
				}

			}
		}      

		if (Input.GetKey (KeyCode.S))
		{
			float angle = transform.eulerAngles.y - 180.0f;

			if (Mathf.Abs(angle) <= 90) {
				if (angle < 0) {
					transform.Rotate (up);
				} else {
					transform.Rotate (down);
				}

			} else {
				if (transform.eulerAngles.y >= 0) {
					transform.Rotate (up);
				} else if (transform.eulerAngles.y <= 359) {
					transform.Rotate (down);
				}
			}
		}

		if (Input.GetKey (KeyCode.D))
		{
			float angle = transform.eulerAngles.y - 90.0f;
			if (Mathf.Abs(angle) <= 90) {
				if (angle < 0) {
					transform.Rotate (up);
				} else {
					transform.Rotate (down);
				}

			} else {
				if (transform.eulerAngles.y >= 270) {
					transform.Rotate (up);
				} else if (transform.eulerAngles.y <= 269) {
					transform.Rotate (down);
				}
			}
		}
	}
}
