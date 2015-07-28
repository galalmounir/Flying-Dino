using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;
using System;
public class GameCenter : MonoBehaviour {
	
	void Start () {
		DontDestroyOnLoad(this);
		// Authenticate and register a ProcessAuthentication callback
		// This call needs to be made before we can proceed to other calls in the Social API
		Social.localUser.Authenticate(ProcessAuthentication);
	}
	
	// This function gets called when Authenticate completes
	// Note that if the operation is successful, Social.localUser will contain data from the server. 
	void ProcessAuthentication (bool success) {
		if (success) {
			Debug.Log ("Authenticated, checking achievements");
			float bestScore = GameVariables.Load ();

			Social.ReportScore(Convert.ToInt64(bestScore),"HIGHSCORE1.1",result => {
				if(result)
					Debug.Log ("Successfully reported score progress");
				else
					Debug.Log ("Failed to report score");
			});
			DisplayScores();
		 // Social.LoadScores ("HIGHSCORE1.0",ProcessLoadedScores); // Make sure to use this.
//			GameCenterPlatform.ShowLeaderboardUI ("HIGHSCORE1.0",TimeScope.AllTime);	//Make sure to use this.


			// Request loaded achievements, and register a callback for processing them
			//Social.LoadAchievements (ProcessLoadedAchievements);
		}
		else
			Debug.Log ("Failed to authenticate");
	}
	public void DisplayScores()
	{
		Social.LoadScores ("HIGHSCORE1.1",ProcessLoadedScores); // Make sure to use this.
		GameCenterPlatform.ShowLeaderboardUI ("HIGHSCORE1.1",TimeScope.AllTime);	//Make sure to use this.
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
	// This function gets called when the LoadAchievement call completes
	/*void ProcessLoadedAchievements (IAchievement[] achievements) {
		if (achievements.Length == 0)
			Debug.Log ("Error: no achievements found");
		else
			Debug.Log ("Got " + achievements.Length + " achievements");
		
		// You can also call into the functions like this
		Social.ReportProgress ("Achievement01", 100.0, result => {
			if (result)
				Debug.Log ("Successfully reported achievement progress");
			else
				Debug.Log ("Failed to report achievement");
		});
	}*/
}