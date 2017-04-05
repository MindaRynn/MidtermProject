using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame3Controller : MonoBehaviour {
	
	public GameObject whiteBox,blackBox;

	// Use this for initialization
	void Start () {
		string maze = "##oo##oo##oo##oo#ooo#o#oo#o##oo#o#o#o##o##oooooo#o#o##o#oo#oo###o#oo#o#o##oo#ooo##o###o#oo#oo#o##o###oo##oo##o##o#oo#oooo###o##oooo###oo#ooo#o###oo##oo#o##oooo##o##oo#o#o#oo#o#o#oooo#oo##o#ooo#o##oo######o##o#oo#ooooo#ooo#o#o";
		int check = 0;
		for (int i = 0; i < 15; i++) {
			for (int j = 0; j < 15; j++) {
				if (maze[check] == 'o') {
					Instantiate(blackBox, new Vector3((float)((-20.5)+(3*j)),0.5f,(-10.5f)+(float)(3*i)), transform.rotation);
					check++;
				} 
				else {
					Instantiate(whiteBox, new Vector3((float)((-20.5)+(3*j)),0.5f,(-10.5f)+(float)(3*i)), transform.rotation);
					check++;
				}
			}
		}
	}
}
