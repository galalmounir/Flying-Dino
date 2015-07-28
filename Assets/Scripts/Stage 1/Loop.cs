using UnityEngine;
using System.Collections;

public class Loop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameManager.gameOver += gameOver;
	}
	
	// Update is called once per frame
	void gameOver()
	{
		Debug.Log("Game Over");
		Time.timeScale=0;
	}

	void OnBecameInvisible() {
		transform.position+=new Vector3(50,0,0);
		enabled = false;
	}

	void OnTriggerEnter2D (Collider2D collidant)
	{
		if (collidant.tag == "Player")
		{
			GameManager.TriggerGameOver();
		}
	}
}
