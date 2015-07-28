using UnityEngine;
using System.Collections;

public class DestroyOnBecomeInvisible : MonoBehaviour {

	// Use this for initialization
	void OnBecameInvisible() {
		Destroy(this.gameObject);
	}
}
