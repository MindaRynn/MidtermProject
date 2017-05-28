using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotterController : MonoBehaviour {
	public GameObject shot;
	public Transform spotSpawn;
	private float fireRate = 0.1f;
	private float fireCounter;
	private float nextFire;

	void Start() {
		fireCounter = fireRate;
	}
	void Update () {
		fireCounter -= Time.deltaTime;
		if (fireCounter < 0)
		{
			Instantiate(shot, spotSpawn.position, spotSpawn.rotation);
			fireCounter = fireRate;
		}
	}
}
