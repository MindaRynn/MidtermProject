using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUdestroyer : MonoBehaviour {

	public GameObject cpuBox;
	public GameObject cpu;
	public GameObject explosion;
	public GameObject UI;
	public AudioClip shooted, explosionSound;
	public GameObject hacker;
	private int count;
	// Use this for initialization
	void Start () {
		count = 0;
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
		if (count >= 20) {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (cpuBox.gameObject);
			hacker.gameObject.GetComponentInParent<HackerCounter> ().PlusCpuDestroyed ();
			Destroy (gameObject);
		}
	}
}
