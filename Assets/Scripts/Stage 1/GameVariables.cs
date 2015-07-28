using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;
using SaveIt;

public class GameVariables : MonoBehaviour {

	public bool isRunning = true,paused = false;
	public GUIText inScore, outScore, bestScore;
	public GameObject InGame, GameOver, Paused;
	[SerializeField]
	public static float Best;

	public static float Score;
	//static GameObject inGame , gameOver;
	public string FileName = "/PlayerInfo2.dat";

	void Awake ()
	{
		Ads.banner.visible = false;
		Ads.ban.Hide();
		Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");

		Time.timeScale = 1;

		//DontDestroyOnLoad(this.transform.parent.gameObject);
	}
	private float LoadHighscore()
	{
		LoadContext context;
		if (Application.isWebPlayer)
			context = LoadContext.FromPlayerPrefs(FileName);
		else
			context = LoadContext.FromFile(FileName);
		
		return context.Load<float>("PlayerInfo2");
		//PointsComponent.HighscoreHolder = context.Load<string>("Holder");
	}
	
	private void SaveHighscore(float score)
	{
		SaveContext context;
		if (Application.isWebPlayer)
			context = SaveContext.ToPlayerPrefs(FileName);
		else
			context = SaveContext.ToFile(FileName);
		
		context.Save(score, "PlayerInfo2");
		//context.Save(PointsComponent.HighscoreHolder, "Holder");
		context.Flush();
	}
	void Start () {
		Score = 0;

		//inGame = Instantiate(InGame) as GameObject;
		//gameOver = Instantiate(GameOver) as GameObject;

		GameOver.gameObject.SetActive(false);
		InGame.gameObject.SetActive(true);

		GameManager.gameOver += Gameover;
		GameManager.gameStart+= Gamestart;
		//Best = Load ();
		Best = PlayerPrefs.GetFloat("Score");
	}

	void Gamestart()
	{
		//Application.LoadLevel("Stage1");
		//Time.timeScale = 1;
		Application.LoadLevel ("Ads");
		//inGame.gameObject.SetActive(true);
		//gameOver.SetActive(false);
		//Time.timeScale = 1;		

	}
	void OnDestroy()
	{
		GameManager.gameOver -= Gameover;
		GameManager.gameStart-= Gamestart;
	}

	void ProcessLoadedScores(IScore[] scores)
	{
		if(scores.Length ==0)
		{
			Debug.Log("No Scores Found !!!");
		}
		else 
		{
			Debug.Log("Got"+scores.Length.ToString () + "scores");
			
		}
	}
	void Gameover()
	{
		Debug.Log ("Score is: "+Score.ToString ());
		//float Best;
		//Debug.Log("GameOVER");

		//Debug.Log("LOADED");
		if(Best < Score)
		{
			Debug.Log("ENTERED IF");
			try
			{ 
				PlayerPrefs.SetFloat ("Score",Score);
				//SavedVariables.SaveVariables();
			//Save();
				//SaveHighscore(Score);
			}
			catch(Exception ex)
			{
				Debug.Log(ex.ToString());
			}
			Debug.Log("Saved");
			Social.ReportScore(Convert.ToInt64(Score),"HIGHSCORE1.1",result => {
				if(result)
				{
					Debug.Log ("Successfully reported score progress");
					Social.LoadScores ("HIGHSCORE1.1",ProcessLoadedScores); // Make sure to use this.
					GameCenterPlatform.ShowLeaderboardUI ("HIGHSCORE1.1",TimeScope.AllTime);
				}
				else
					Debug.Log ("Failed to report score");
			});

		//	Debug.Log("SAVED");
			Best = Score;
			Kiip.saveMoment("Achieving a HIGHSCORE !!!",Best);
		//	Debug.Log("Done IF");
		}
		else
		{
			if (Score > 10)
				Kiip.saveMoment("Doing Great !!!",Score);
			//revMob.ShowFullscreen ();
		}
		GameOver.SetActive(true);
		outScore.text = "Score : "+Score;
		bestScore.text = "Best : "+Best;
		if(Best == Score)
			bestScore.color = Color.magenta;
		InGame.gameObject.SetActive(false);
		isRunning = false;
		paused = true;
		//Score = 0;
	}

	void OnGUI ()
	{
		if ((Input.touchCount > 0 || Input.anyKeyDown) && !isRunning)
		{
			GameManager.TriggerGameStart();
		}
		inScore.text = "Score : " + Score;
		GUI.Label(new Rect(0.5f,-0.5f,10,10),Score.ToString());
		if(!paused && isRunning)
		{
			if(GUI.Button(new Rect(Screen.width - (Screen.width*11/100f),(Screen.height * 1 )/100,Screen.width*10/100f,Screen.width*10/100f),"II"))
			{
				Time.timeScale = 0;
				InGame.SetActive(false);
				Paused.SetActive(true);
				paused = true;
			}
		}
		else if (isRunning)
		{
			if(GUI.Button(new Rect(Screen.width/2 - (Screen.width*25/100f)/2,Screen.height/2 + (Screen.height*10/100f)/2,(Screen.width*25/100f),(Screen.height*10/100f)),"Resume"))
			{
				Time.timeScale = 1;
				InGame.SetActive(true);
				Paused.SetActive(false);
				paused = false;
			}
		}

	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		if(File.Exists (Application.persistentDataPath + "/PlayerInfo.dat"))
		{
			Debug.Log("YES");
			FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.dat",FileMode.Open);
			Debug.Log("Opened");
			playerData data = new playerData();
			Debug.Log("Created new playerData");
			data.Score = Score;
			Debug.Log("Before Serialize");
			bf.Serialize(file,Score);

			Debug.Log("After Serialize");
			file.Close ();
			Debug.Log("Closed");
		}
		else
		{
			Debug.Log("NO");
			FileStream file = File.Create(Application.persistentDataPath + "/PlayerInfo.dat");
			
			playerData data = new playerData();
			data.Score = Score;
			
			bf.Serialize(file,Score);
			file.Close ();
		}
	}

	public static float Load()
	{
		if(File.Exists(Application.persistentDataPath + "/PlayerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.dat",FileMode.Open);
			float test  =(float)bf.Deserialize(file);
			file.Close();

			return test;
		}
		else
			return 0;
	}
}

[System.Serializable]
class playerData 
{
	public float Score;
}
