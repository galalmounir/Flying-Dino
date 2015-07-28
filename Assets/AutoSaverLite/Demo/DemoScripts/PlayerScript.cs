using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    [SerializeField]
    private int rs;

    void Start()
    {
        SavedVariables.Load();  // quickly load up your variables
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Player Name: ");
        Variables.playerName = GUILayout.TextField(Variables.playerName);

        GUILayout.EndHorizontal();
        GUILayout.Label("Player Level: " + Variables.playerLevel);
        GUILayout.Label("Player Experience: " + Variables.playerExpereience + " / " + Variables.playerExpereinceTillNextLevel);
        
        GUILayout.Label("");
        GUILayout.Label("Stats");
        GUILayout.Label("-------");
        GUILayout.Label("Move Speed: " + Variables.moveSpeed);
        GUILayout.Label("Attack Speed: " + Variables.attackSpeed);

        if (GUILayout.Button("Kill Monster"))
        {
            KillMonster();
        }
        if (GUILayout.Button("Load"))
        {
            SavedVariables.Load();
        }
        if (GUILayout.Button("Save"))
        {
            // save any time during the game
            SavedVariables.SaveVariables();
        }
    }

    void KillMonster()
    {
        int expGained = Random.Range(5, 200);

        Variables.playerExpereience += expGained;
        if (Variables.playerExpereience >= Variables.playerExpereinceTillNextLevel)
        {
            // adjust your variables you want to update
            Variables.playerLevel++;
            Variables.playerExpereience -= Variables.playerExpereinceTillNextLevel;
            Variables.attackSpeed += 0.3f;
            Variables.moveSpeed += 0.1f;
            Variables.playerExpereinceTillNextLevel *= 2;
            // quickly save them
            SavedVariables.SaveVariables();
        }
    }
}
