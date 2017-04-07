using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotterController : MonoBehaviour {
	public GameObject shot;
	public Transform spotSpawn;
	public float fireRate;
	private float nextFire;

	void Update () {
		if (Time.time > nextFire)
		{
			nextFire += fireRate;
			Instantiate(shot, spotSpawn.position, spotSpawn.rotation);
		}
	}
}
