﻿using UnityEngine;
using System.Collections;

public class DestroyIfCollide : MonoBehaviour {
	
	void OnBecameInvisible() {
		Destroy(this.gameObject);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
