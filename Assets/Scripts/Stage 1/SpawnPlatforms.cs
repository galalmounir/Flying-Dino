using UnityEngine;
using System.Collections;

public class SpawnPlatforms : MonoBehaviour {
	public GameObject[] Platforms;
	public GameObject Player;
	public GameObject[] Mountain;
	public Vector2 mSize,sSize,size;
	public Texture2D MountainTexture;
	public float platformTimeInstatiation = 1f;
	public bool instantiateMountain = true;
	// Use this for initialization
	void Start () {
		sSize = new Vector2(Camera.main.pixelWidth,Camera.main.pixelHeight);

		mSize = new Vector2(MountainTexture.width/100f,MountainTexture.height/100f);
		InvokeRepeating("instantiatePlatforms",0,platformTimeInstatiation);
		if (instantiateMountain)
			InvokeRepeating("instantiateMountains",2f,2f);
	}

	void instantiatePlatforms()
	{
		int x;

		x = Random.Range(0,Platforms.Length);
		GameObject OK = Instantiate(Platforms[x],new Vector3(Player.transform.position.x + 10f + Platforms[x].GetComponent<Renderer>().bounds.size.x,Random.Range(-(size.y)/2,(size.y)/2),0),new Quaternion ()) as GameObject;
		OK.transform.parent = this.gameObject.transform;
	}
	void instantiateMountains()
	{
		float x = Random.Range(0f,12f);
		GameObject OK = Instantiate(Mountain[0],new Vector3(Player.transform.position.x + 13f, -22 + x ,0),new Quaternion()) as GameObject;
		OK.transform.parent = this.gameObject.transform;
		OK = Instantiate(Mountain[1],new Vector3(Player.transform.position.x + 13f, 10 +x,0),new Quaternion(0,0,180,0)) as GameObject;
		OK.transform.parent = this.gameObject.transform;
	}
	// Update is called once per frame
	void Update () {
		//Debug.Log("Width: " + Screen.width +", Height: "+ Screen.height);
	}
}
