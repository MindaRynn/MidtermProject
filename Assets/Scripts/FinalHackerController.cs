﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalHackerController : MonoBehaviour {



	public GameObject shot;
	public Transform spotSpawn;
	public float speed;
	private float fireRate = 0.1f;
	private float fireCounter;
	private float nextFire;
	private bool isDead;

	//	public Boundary boundary;
	public Vector3 up = new Vector3(0,1.0f,0);
	public Vector3 down = new Vector3(0,-1.0f,0);
	float lockPos = 0;

	void Start() {
		fireCounter = fireRate;
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody> ().velocity = movement * speed;
		isDead = false;
	}

	void OnTriggerEnter (Collider other){
		if ((other.tag == "eShot" || other.tag == "EnemyBolt")&&!isDead) {
			Destroy (other.gameObject);
			transform.position = new Vector3 (0, 1.5f, -31.74f);
			isDead = true;
		}
	}

	void Update () {
		transform.rotation = Quaternion.Euler(lockPos, transform.rotation.eulerAngles.y, lockPos);

		fireCounter -= Time.deltaTime;
		if (fireCounter < 0)
		{
			Instantiate(shot, spotSpawn.position, spotSpawn.rotation);
			fireCounter = fireRate;
		}

		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0,-angle,0));
	}
}
