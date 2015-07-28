using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq.Expressions;
using System.Linq;

public static class SavedVariables {

    /// <summary>
    /// Use this to save all your variables in the Variables.cs file
    /// </summary>
    public static void SaveVariables() {

        var fields = typeof(Variables).GetFields();
        
        for (int i = 0; i < fields.Length; i++) {
            if(fields[i].IsPublic){

                if (fields[i].FieldType == typeof(float)) {
                    PlayerPrefs.SetFloat(fields[i].Name, (float)fields[i].GetValue(null));
                }
                else if (fields[i].FieldType == typeof(int)) {
                    PlayerPrefs.SetInt(fields[i].Name, (int)fields[i].GetValue(null));
                }
                else if (fields[i].FieldType == typeof(string)) {
                    PlayerPrefs.SetString(fields[i].Name, (string)fields[i].GetValue(null));
                }
                else if (fields[i].FieldType == typeof(bool)) {
                    Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                }
                else if (fields[i].FieldType == typeof(double)) {
                    Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                }
                else if (fields[i].FieldType == typeof(Vector2)) {
                    Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                }
                else if (fields[i].FieldType == typeof(Vector3)) {
                    Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                }
                else {
                    if (fields[i].FieldType == typeof(List<int>)) {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else if (fields[i].FieldType == typeof(List<bool>)) {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else if (fields[i].FieldType == typeof(List<float>)) {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else if (fields[i].FieldType == typeof(List<string>)) {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else if (fields[i].FieldType == typeof(List<double>))
                    {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else if (fields[i].FieldType == typeof(List<Vector2>))
                    {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else if (fields[i].FieldType == typeof(List<Vector3>))
                    {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else
                    {
                        // old
                        Debug.LogError("ERROR: " + fields[i].FieldType + " IS NOT A VALID VARIABLE TYPE");
                    }
                }
            }
        }

        PlayerPrefs.SetInt("savedVariable", 1);
    }
    /// <summary>
    /// Use this to save all your variables in the Variables.cs file
    /// </summary>
    /// <param name="index">Call what index you want to save your files at</param>
    public static void SaveVariables(int index) {
        var fields = typeof(Variables).GetFields();

        for (int i = 0; i < fields.Length; i++) {
            if (fields[i].IsPublic) {
                if (fields[i].FieldType == typeof(float)) {
                    PlayerPrefs.SetFloat(fields[i].Name + index.ToString(), (float)fields[i].GetValue(null));
                }
                else if (fields[i].FieldType == typeof(int)) {
                    PlayerPrefs.SetInt(fields[i].Name + index.ToString(), (int)fields[i].GetValue(null));
                }
                else if (fields[i].FieldType == typeof(string)) {
                    PlayerPrefs.SetString(fields[i].Name + index.ToString(), (string)fields[i].GetValue(null));
                }
                else if (fields[i].FieldType == typeof(bool)) {
                    Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                }
                else if (fields[i].FieldType == typeof(double)) {
                    Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                }
                else if (fields[i].FieldType == typeof(Vector2)) {
                    Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                }
                else if (fields[i].FieldType == typeof(Vector3)) {
                    Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                }
                else {
                    if (fields[i].FieldType == typeof(List<int>)) {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else if (fields[i].FieldType == typeof(List<bool>)) {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else if (fields[i].FieldType == typeof(List<float>)) {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else if (fields[i].FieldType == typeof(List<string>)) {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else if (fields[i].FieldType == typeof(List<double>)) {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else if (fields[i].FieldType == typeof(List<Vector2>))
                    {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else if (fields[i].FieldType == typeof(List<Vector3>))
                    {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else
                        Debug.LogError("ERROR: " + fields[i].FieldType + " IS NOT A VALID VARIABLE TYPE");
                }
            }
        }

        PlayerPrefs.SetInt("savedVariable" + index.ToString(), 1);
    }

    /// <summary>
    /// Use this to quickly load all your saved data to your Variables.cs file
    /// </summary>
    public static void Load() {
        var fields = typeof(Variables).GetFields();
        int savedVariable = PlayerPrefs.GetInt("savedVariable");

        if (savedVariable == 1) {
            for (int i = 0; i < fields.Length; i++) {
                if (fields[i].IsPublic) {

                    if (fields[i].FieldType == typeof(float)) {
                        fields[i].SetValue(null, PlayerPrefs.GetFloat(fields[i].Name));
                    }
                    else if (fields[i].FieldType == typeof(int)) {
                        fields[i].SetValue(null, PlayerPrefs.GetInt(fields[i].Name));
                    }
                    else if (fields[i].FieldType == typeof(string)) {
                        fields[i].SetValue(null, PlayerPrefs.GetString(fields[i].Name));
                    }
                    else if (fields[i].FieldType == typeof(bool)) {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else if (fields[i].FieldType == typeof(double)) {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else if (fields[i].FieldType == typeof(Vector2)) {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");

                    }
                    else if (fields[i].FieldType == typeof(Vector3)) {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else {
                        if (fields[i].FieldType == typeof(List<int>)) {
                            Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                        }
                        else if (fields[i].FieldType == typeof(List<bool>)) {
                            Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                        }
                        else if (fields[i].FieldType == typeof(List<float>)) {
                            Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                        }
                        else if (fields[i].FieldType == typeof(List<string>)) {
                            Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                        }
                        else if (fields[i].FieldType == typeof(List<double>))
                        {
                            Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                        }
                        else if (fields[i].FieldType == typeof(List<Vector2>))
                        {
                            Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                        }
                        else if (fields[i].FieldType == typeof(List<Vector3>))
                        {
                            Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                        }
                        else
                        {
                            // old
                            Debug.LogError("ERROR: " + fields[i].FieldType + " IS NOT A VALID VARIABLE TYPE");
                        }
                    }
                }
            }
        }
        else {
            Debug.LogWarning("NO SAVED DATA, PLEASE SAVE YOUR DATA BEFORE YOU TRY AND LOAD ANY INFORMATION");
        }
        
    }

    /// <summary>
    /// Use this to quickly load all your saved data to your Variables.cs file
    /// </summary>
    /// <param name="index">Call the index you want to load from</param>
    public static void Load(int index) {
        var fields = typeof(Variables).GetFields();
        int savedVariable = PlayerPrefs.GetInt("savedVariable" + index.ToString());
        Debug.Log(savedVariable);
        
        if (savedVariable == 1) {
            for (int i = 0; i < fields.Length; i++) {
                if (fields[i].IsPublic) {
                    if (fields[i].FieldType == typeof(float)) {
                        fields[i].SetValue(null, PlayerPrefs.GetFloat(fields[i].Name + index.ToString()) );
                    }
                    else if (fields[i].FieldType == typeof(int)) {
                        fields[i].SetValue(null, PlayerPrefs.GetInt(fields[i].Name + index.ToString()) );
                    }
                    else if (fields[i].FieldType == typeof(string)) {
                        fields[i].SetValue(null, PlayerPrefs.GetString(fields[i].Name + index.ToString()));
                    }
                    else if (fields[i].FieldType == typeof(bool)) {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else if (fields[i].FieldType == typeof(double)) {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else if (fields[i].FieldType == typeof(Vector2)) {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");

                    }
                    else if (fields[i].FieldType == typeof(Vector3)) {
                        Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                    }
                    else {
                        if (fields[i].FieldType == typeof(List<int>)) {
                            Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                        }
                        else if (fields[i].FieldType == typeof(List<bool>)) {
                            Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                        }
                        else if (fields[i].FieldType == typeof(List<float>)) {
                            Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                        }
                        else if (fields[i].FieldType == typeof(List<string>)) {
                            Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                        }
                        else if (fields[i].FieldType == typeof(List<double>)) {
                            Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                        }
                        else if (fields[i].FieldType == typeof(List<Vector2>))
                        {
                            Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                        }
                        else if (fields[i].FieldType == typeof(List<Vector3>))
                        {
                            Debug.LogError("YOU NEED PRO TO USE THIS VARIABLE TYPE");
                        }
                        else
                            Debug.LogError("ERROR: " + fields[i].FieldType + " IS NOT A VALID VARIABLE TYPE");
                    }
                }
            }
        }
        else {
            Debug.LogWarning("NO SAVED DATA, PLEASE SAVE YOUR DATA BEFORE YOU TRY AND LOAD ANY INFORMATION");
        }

    }
    /// <summary>
    /// Deletes all your saved data, you can use the saved variables window editor to call this
    /// </summary>
    public static void DeleteAll() {
        PlayerPrefs.DeleteAll();
    }

    public static List<FieldInfo> ReturnType() {
        var fields = typeof(Variables).GetFields();

        List<FieldInfo> namesOfVariables = new List<FieldInfo>();

        for (int i = 0; i < fields.Length; i++) {
            namesOfVariables.Add(fields[i]);
        }

        return namesOfVariables;
    }
}

