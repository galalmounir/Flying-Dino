using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Use this class to save all the variables you want to save such as player expereince, gold, levels unlocked, etc.
/// I normally make mine static but you dont have too, just easier
/// 
/// </summary>
public static class Variables {

    public static float volumeMusic = 1.0f;
    public static float volumeSFX = 1.0f;

    public static int playerExpereience = 0;
    public static int playerExpereinceTillNextLevel = 100;
    public static int playerLevel = 1;

    public static string playerName = "Dex Robinson";

    public static float moveSpeed = 1.0f;
    public static float attackSpeed = 3.0f;

    public static float newData;

}