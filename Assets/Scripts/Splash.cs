using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {
	public Texture[] logo;
	// Use this for initialization
	void Start () {
		float width,height;
		width = Screen.width;
		height = Screen.height;
		string device = SystemInfo.deviceModel.ToString ();
		switch (device)
		{
		case "iPod1,1":
		case "iPod3,1":
		case "iPod4,1":
		case "iPhone1,1":
		case "iPhone1,2":
		case "iPhone2,1":
		case "iPhone3,1":
		case "iPhone4,1":
			this.GetComponent<GUITexture>().texture = logo[1];
			break;

		case "iPhone5,3":
		case "iPhone5,4":
		case "iPhone6,1":
		case "iPhone6,2":
			this.GetComponent<GUITexture>().texture = logo[2];
			break;

		case "iPad1,1":
		case "iPad2,1":
		case "iPad3,1":
			this.GetComponent<GUITexture>().texture = logo[3];
			break;

		case "iPad4,1":
		case "iPad4,2":
		case "iPad4,4":
		case "iPad4,5":
			this.GetComponent<GUITexture>().texture = logo[4];
			break;

		default:
			this.GetComponent<GUITexture>().texture = logo[0];
			break;
		}
		this.GetComponent<GUITexture>().pixelInset = new Rect(-width/2,-height/2,width,height);
		//this.guiTexture.pixelInset.width = width;
		//this.guiTexture.pixelInset.height = height;
		//this.guiTexture.pixelInset.x = - width/2;
		//this.guiTexture.pixelInset.y = - height/2;
		StartCoroutine(delay());
	}

	IEnumerator delay()
	{
		yield return new WaitForSeconds(3);
		Application.LoadLevelAsync ("Welcome");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
