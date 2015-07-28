using UnityEngine;
using System.Collections;

public class MultiIndexSaving : MonoBehaviour {

    private string indexSaveSlot = "0";

    void Start()
    {
        SavedVariables.Load(int.Parse(indexSaveSlot));  // same as before, but just throw a save index in to load from a specfic area
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Load From Index: ");
        indexSaveSlot = GUILayout.TextField(indexSaveSlot);

        GUILayout.EndHorizontal();

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
        if (GUILayout.Button("Save"))
        {
            SavedVariables.SaveVariables(int.Parse(indexSaveSlot)); // now just add an index and it will save multiple files
        }
        if (GUILayout.Button("Load"))
        {
            SavedVariables.Load(int.Parse(indexSaveSlot));
        }
    }

    void KillMonster()
    {
        int expGained = Random.Range(5, 200);

        Variables.playerExpereience += expGained;
        if (Variables.playerExpereience >= Variables.playerExpereinceTillNextLevel)
        {
            Variables.playerLevel++;
            Variables.playerExpereience -= Variables.playerExpereinceTillNextLevel;
            Variables.attackSpeed += 0.3f;
            Variables.moveSpeed += 0.1f;
            Variables.playerExpereinceTillNextLevel *= 2;

            SavedVariables.SaveVariables(int.Parse(indexSaveSlot));
        }
    }
}
