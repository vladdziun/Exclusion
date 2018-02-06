﻿using UnityEngine;
using System.Collections;

public class BasicMover : MonoBehaviour {
	public bool doSpin = true;
	public bool doMotion = false;
	public float spinSpeed = 180.0f;
	public float motionMagnitude = 0.1f; //
	
	// Update is called once per frame
	void Update () {
		if (doSpin) {
			gameObject.transform.Rotate (Vector3.up * spinSpeed * Time.deltaTime); //rotate around y axis
		}

		if (doMotion) {
			gameObject.transform.Translate (Vector3.up * Mathf.Cos (Time.timeSinceLevelLoad) * motionMagnitude);
		}
	}
}