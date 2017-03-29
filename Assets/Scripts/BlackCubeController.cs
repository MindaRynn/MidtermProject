using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCubeController : MonoBehaviour {
	private int count;
	public GameObject blackcube;
	public GameObject explosion;
	public AudioClip shooted, explosionSound;
	// Use this for initialization
	void Start () {
		count = 0;
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "Bolt") {
			blackcube.GetComponent<Renderer>().material.color = new Color(0.267F,0.267F, 0.267F, 1.0F);
			count = count + 1;
			AudioSource.PlayClipAtPoint(shooted, transform.position,1.0f);
		}
		if (other.tag == "eShot") {
			Destroy (other.gameObject);
		}
	}

	void OnTriggerExit (Collider other){
		if (other.tag == "Bolt") {
			blackcube.GetComponent<Renderer>().material.color = new Color(0.067F,0.067F, 0.067F, 1.0F);
			Destroy (other.gameObject);
			AudioSource.PlayClipAtPoint(explosionSound, transform.position,1.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (count >= 6) {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (blackcube.gameObject);
			Destroy (gameObject);
		}
	}
}
