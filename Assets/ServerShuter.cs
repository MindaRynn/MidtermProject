using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerShuter : MonoBehaviour {

	public GameObject cpuBox;
	public GameObject cpu;
	public GameObject explosion;
	public AudioClip shooted, explosionSound;
	private int count;
	public GameObject faderObj;
	private Fader fader;
	bool destroyed;
	// Use this for initialization
	void Start () {
		count = 0;
		fader = faderObj.GetComponent<Fader> ();
		destroyed = false;
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "Bolt") {
			cpu.GetComponent<Renderer>().material.color = new Color(0.267F,0.267F, 0.267F, 1.0F);
			count = count + 1;
			AudioSource.PlayClipAtPoint(shooted, transform.position,1.0f);
		}
	}

	void OnTriggerExit (Collider other){
		if (other.tag == "Bolt") {
			cpu.GetComponent<Renderer>().material.color = new Color(0.494F,0.494F, 0.494F, 1.0F);
			Destroy (other.gameObject);
			AudioSource.PlayClipAtPoint(explosionSound, transform.position,1.0f);
		}
	}

	// Update is called once per frame
	void Update () {
		if (count >= 40 && !destroyed) {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (cpuBox.gameObject);
			Destroy (gameObject);
			fader.gameObject.SetActive (true);
			destroyed = true;
			fader.FadeOutAndLoad ("FinalScene");
		}
	}
}
