using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMiniGameController : MonoBehaviour {

	public GameObject whiteBox,blackBox;
	public GameObject hacker;
	private int cpuNum;
	public GameObject gate1;
	public bool gateDestroyed;

	// Use this for initialization
	void Start () {
		gateDestroyed = false;
		cpuNum = 2;
		string maze = "oo##oo##oo##oo##oo##oo##ooo#ooo#o#oo#o#o#oo#ooo#o#o##o#o#o##ooo#o#o#oo#o#ooo#o##o#oo##o##oo#oo##o##oooo#oo###o#oo#o##o###oo#o##o#o#ooo#ooo##o#o##o#oooooo#o#o#o###oo###o##oo##oo###oooooooo#o#o#o##oooooooo####o##oo#ooo#o#oo######o#oooo#oo#o##ooo#o#o#o##oo#o#oo#o#oo#o##ooo###oooo##oo##oo#o####ooo#oo##oo#o##o##o##o#o#oo##o#o#oooo#ooo##o#oo#ooo#ooo#ooooo#oo#o#oo#o##o##o#oo####o#oo####o##o##o#o#####oo#o#o###o####o#oo#o##ooo#####oo#o#ooo#ooo##o#####ooooo#o###o#o#o##o#ooooo#oo#oo#ooooo#oo#ooo#ooo######oo#####o##o###o#o##ooooooo#ooooo#o#o#o#o#o##o#ooooooo#ooo##oo#o#o####oo####ooo###oo#o##ooo#ooo#o##ooo##o#o#o#o#oo##o#oo#o##o##";
		int check = 0;
		for (int i = 0; i < 25; i++) {
			for (int j = 0; j < 25; j++) {
				if (maze[check] == 'o') {
					Instantiate(blackBox, new Vector3((float)((-60)+(3*j)),0.5f,(99f)+(float)(3*i)), transform.rotation);
					check++;
				} 
				else {
					Instantiate(whiteBox, new Vector3((float)((-60)+(3*j)),0.5f,(99f)+(float)(3*i)), transform.rotation);
					check++;
				}
			}
		}
	}

	void Update(){
		if (hacker.gameObject.GetComponentInParent<HackerCounter>().getCpuDestroyed() >= cpuNum && !gateDestroyed) {
			gate1.gameObject.GetComponentInParent<GateController> ().DestroyGate ();
			gateDestroyed = true;
		}
	}
}
