using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackerCounter : MonoBehaviour {
	public int cpuDestroyed;
	// Use this for initialization
	void Start () {
		cpuDestroyed = 0;
	}

	public int getCpuDestroyed(){
		return cpuDestroyed;
	}

	public void PlusCpuDestroyed(){
		cpuDestroyed += 1;
		Debug.Log (cpuDestroyed);
	}
}
