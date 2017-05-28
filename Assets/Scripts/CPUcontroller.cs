using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUcontroller : MonoBehaviour {
	public GameObject shot1,shot2,shot3,shot4;
	public Transform spotSpawn1,spotSpawn2,spotSpawn3,spotSpawn4;
	private float fireRate = 0.3f;
	private float fireCounter;
	private float nextFire;

	void Start() {
		fireCounter = fireRate;
	}
	// Update is called once per frame
	void Update () {
		fireCounter -= Time.deltaTime;
		if (fireCounter < 0)
		{
			Instantiate(shot1, spotSpawn1.position, spotSpawn1.rotation);
			Instantiate(shot2, spotSpawn2.position, spotSpawn2.rotation);
			Instantiate(shot3, spotSpawn3.position, spotSpawn3.rotation);
			Instantiate(shot4, spotSpawn4.position, spotSpawn4.rotation);
			fireCounter = fireRate;
		}


	}
}
