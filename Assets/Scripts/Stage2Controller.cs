using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Controller : MonoBehaviour {

	public GameObject zombiePrefab;
	private Vector3[] zombiesPos;
	private GameObject[] zombies;
	public int zombieRespawnDelay;
	private int respawnCount;

	// Use this for initialization
	void Awake () {
		InitializeZombiesPos ();
		InstantiateZombies ();
		respawnCount = 0;
	}

	private void InitializeZombiesPos () {
		Debug.Log ("InitializeZombiesPos");
		zombiesPos = new Vector3[17];
		zombiesPos[0] = new Vector3 (165, 61, 0);
		zombiesPos[1] = new Vector3 (190, 61, 0);
		zombiesPos[2] = new Vector3 (163, 86, 0);
		zombiesPos[3] = new Vector3 (150, 81, 0);
		zombiesPos[4] = new Vector3 (142, 76, 0);
		zombiesPos[5] = new Vector3 (222, 100, 0);
		zombiesPos[6] = new Vector3 (200, 85, 0);
		zombiesPos[7] = new Vector3 (210, 70, 0);
		zombiesPos[8] = new Vector3 (250, 100, 0);
		zombiesPos[9] = new Vector3 (275, 100, 0);
		zombiesPos[10] = new Vector3 (245, 95, 0);
		zombiesPos[11] = new Vector3 (270, 95, 0);
		zombiesPos[12] = new Vector3 (185, 51, 0);
		zombiesPos[13] = new Vector3 (200, 51, 0);
		zombiesPos[14] = new Vector3 (430, 100, 0);
		zombiesPos[15] = new Vector3 (460, 100, 0);
		zombiesPos[16] = new Vector3 (485, 100, 0);
		zombies = new GameObject[zombiesPos.Length];
	}

	private void InstantiateZombies () {
		Debug.Log ("InstantiateZombies");
		for (int i = 0; i < zombiesPos.Length; i++) {
			if (zombies [i] == null) {
				zombies [i] = Instantiate (zombiePrefab, zombiesPos [i], Quaternion.identity);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		respawnCount++;
		if (respawnCount >= zombieRespawnDelay) {
			InstantiateZombies ();
			respawnCount = 0;
		}
	}
}
