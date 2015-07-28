using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class Ads : MonoBehaviour {


	public GUIText guitext;

	public static UnityEngine.iOS.ADBannerView banner = null;
	private static readonly Dictionary<string, string> REVMOB_APP_IDS = new Dictionary<string, string>() {
		{ "Android", "copy your Android RevMob App ID here"},
		{ "IOS", "537f51e594fde2c7283b7774" }
	};
	bool showRev = false,clicked = false;
	private RevMob revMob;
	//public static RevMobBanner ban;
	public static RevMobBanner ban;
	bool tried = false;
	void Awake()
	{
		Time.timeScale = 1;
		try
		{
			revMob = RevMob.Start (REVMOB_APP_IDS,"GameObject");
			ban = revMob.CreateBanner();//(0,0,350,50,null,null);
		//revMob.CreateBanner (0,0,350,50,null,null);
			tried  = true;
		}
		catch
		{
		}
		//revMob.SetTimeoutInSeconds (5);
		Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
		Debug.Log("HI "+tried.ToString () );


	}
	void unload()
	{
		#if UNITY_ANDROID || UNITY_IPHONE
		ban.Hide();

		#endif
		return;
	}


	void Start () {

		//ban = revMob.CreateBanner(0,0,350,50,null,null);
		//revMob.CreateFullscreen();
		//Debug.Log("WAIT STARTED");
		Debug.Log ("Start");
		banner = new UnityEngine.iOS.ADBannerView(UnityEngine.iOS.ADBannerView.Type.Banner, UnityEngine.iOS.ADBannerView.Layout.Bottom);

//		ADBannerView.onBannerWasClicked += OnBannerClicked;
		UnityEngine.iOS.ADBannerView.onBannerWasLoaded  += OnBannerLoaded;

	//	StartCoroutine (Check ());
		Debug.Log ("Before Score");
		guitext.text = PlayerPrefs.GetFloat ("Score").ToString();

		Debug.Log ("After Score");
		StartCoroutine(delay());
	}
	IEnumerator delay()
	{
		Debug.Log ("Called");
		yield return new WaitForSeconds(0.2f);
		if(!banner.loaded && !showRev && tried)
		{

			ban.Show ();
			Debug.Log ("Did again");
			//banner = null;
			showRev = true;
		}
		Debug.Log ("Waited 0.2");
		yield return new WaitForSeconds(4.8f);
		banner.visible = false;
		if(tried)
		{
			ban.Hide ();
		unload ();
		}
		Debug.Log ("Loading Level");
		loadLevel ();


	}
	void OnGUI()
	{
		/*if(GUI.Button(new Rect(Screen.width/2,Screen.height/2,150,50)," "))
		{
			banner.visible = false;

			ban.Hide();
			unload();
			loadLevel();
			return;
		}*/
	}

	void loadLevel()
	{
		Application.LoadLevel("Stage1");
	}
	IEnumerator Check()
	{
		yield return new WaitForSeconds(0.2f);

	}

	void OnBannerLoaded()
	{
		if(Application.loadedLevelName == "Ads" && showRev == false)
		{
			Debug.Log("Loaded!\n");
			banner.layout = UnityEngine.iOS.ADBannerView.Layout.Bottom;
			banner.visible = true;
			showRev = true;
		}
	}

}

