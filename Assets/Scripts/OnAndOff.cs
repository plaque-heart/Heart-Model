﻿using UnityEngine;
using System.Collections;

public class OnAndOff : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
			gameObject.SetActive(false);
		//else:
			//gameObject.SetActive(true);
	}
}
