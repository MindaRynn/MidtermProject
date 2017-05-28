using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackerController : MonoBehaviour {


	public GameObject shot;
	public Transform spotSpawn;
	public float speed;
	private float fireRate = 0.1f;
	private float fireCounter;
	private float nextFire;
	public GameObject explosion;
	public GameObject faderObj;
	private Fader fader;
	private bool isDead;

	//	public Boundary boundary;
	public Vector3 up = new Vector3(0,1.0f,0);
	public Vector3 down = new Vector3(0,-1.0f,0);
	float lockPos = 0;

	void Awake () {
		fader = faderObj.GetComponent<Fader> ();
		isDead = false;
		fireCounter = fireRate;
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody> ().velocity = movement * speed;
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "eShot" && !isDead) {
			Destroy (other.gameObject);
			gameObject.GetComponent<Renderer>().enabled = false;
			Instantiate (explosion, transform.position, transform.rotation);
			PlayerPrefs.SetInt ("data"+PlayerPrefs.GetInt("numHacking"), 0);
			PlayerPrefs.SetInt ("numHacking", 0);
			fader.gameObject.SetActive (true);
			fader.FadeOutAndLoad ("MainStage1");
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
