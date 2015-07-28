using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public GameObject Target;
	private Vector3 position;
	public float tolerance = 10f;
	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		position.x = Target.transform.position.x + tolerance;
		transform.position = position;
	}
}
