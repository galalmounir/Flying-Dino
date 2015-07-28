using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public delegate void GameEvent();

	public static GameEvent gameStart, gameOver; 

	public static void TriggerGameStart()
	{
		if (gameStart != null)
		{
			gameStart();	
		}
	}
	
	public static void TriggerGameOver()
	{
		if (gameOver != null)
		{
			gameOver();	
		}
	}
}
