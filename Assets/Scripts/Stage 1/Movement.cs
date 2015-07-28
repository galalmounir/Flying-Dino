using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	//public float speed = 5f;
	public Vector3 speed = new Vector3 (5,0,0);
	public float jump = 100;
	public bool rotate = true;
	public bool welcome = false;
	public bool ads = false;
	// Use this for initialization
	void Start () {

		GetComponent<Rigidbody2D>().transform.rotation = new Quaternion(0,0,0,0);
	}
	IEnumerator playsound()
	{
		GetComponent<AudioSource>().Play();
		//yield return new WaitForSeconds(1f);
		//audio.Stop ();
		return null;
	}
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D>().transform.localPosition += speed*Time.fixedDeltaTime;
		if(!welcome)
		{
			if ( Input.touchCount>0|| Input.anyKeyDown)
			{

				playsound ();	
				//audio.PlayOneShot (audio.clip);
				GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jump));
				if (GetComponent<Rigidbody2D>().transform.localRotation.eulerAngles.z < 45 ||  GetComponent<Rigidbody2D>().transform.localRotation.eulerAngles.z > 90  && rotate)
				{
					if( GetComponent<Rigidbody2D>().transform.localRotation.eulerAngles.z < 0)
						GetComponent<Rigidbody2D>().transform.Rotate(Vector3.forward * 45);
					else if (GetComponent<Rigidbody2D>().transform.localRotation.eulerAngles.z >= 270)
						GetComponent<Rigidbody2D>().transform.Rotate(Vector3.forward * 90);
				}
			}
			else
			{
				if (GetComponent<Rigidbody2D>().transform.localRotation.eulerAngles.z < 270 || GetComponent<Rigidbody2D>().transform.localRotation.eulerAngles.z > 275 && rotate)
					GetComponent<Rigidbody2D>().transform.Rotate(Vector3.back * 70f * Time.fixedDeltaTime);
			}
		}
		else if (Input.touchCount > 0 || Input.anyKeyDown)
		{
			//Application.LoadLevel("Stage1");
			if(Application.loadedLevelName != "Ads")
				Application.LoadLevelAsync("Ads");
		}

	}

	void OnCollisionEnter2D(Collision2D collidant)
	{
		if (collidant.collider.GetComponent<Collider2D>().tag== "Mountain")
		{
			Time.timeScale = 0f;
			GameManager.TriggerGameOver();
		}
	}

	void OnTriggerExit2D(Collider2D collidant)
	{
		if (collidant.GetComponent<Collider2D>().tag == "Mountain")
		{
			GameVariables.Score++;
			if(GameVariables.Score > GameVariables.Best)
			{

			}
		}
	}
}

