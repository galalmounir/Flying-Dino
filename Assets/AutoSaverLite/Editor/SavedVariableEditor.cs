using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

public class SavedVariableEditor : EditorWindow {
    private static List<FieldInfo> fields = new List<FieldInfo>();
    private int numberOfSlots = 0;
    private Vector2 scrollPosition;
    private bool areYouSureWindow;

    // Add menu named "My Window" to the Window menu
    [MenuItem("Save Editor/Saved Varible Editor")]
    static void Init() {
        // Get existing open window or if none, make a new one:
        SavedVariableEditor window = (SavedVariableEditor)EditorWindow.GetWindow(typeof(SavedVariableEditor));
        fields = SavedVariables.ReturnType();
    }

    void OnGUI() {
        if (areYouSureWindow) {
            GUILayout.Label("Are you sure you want to delete all your current player pref values?");

            if (GUILayout.Button("Yes")) {
                SavedVariables.DeleteAll();
                areYouSureWindow = !areYouSureWindow;
            }
            if (GUILayout.Button("No")) {
                areYouSureWindow = !areYouSureWindow;
            }
        }
        else {
            GUILayout.Label("Number of Save Slots");
            numberOfSlots = EditorGUILayout.IntField(numberOfSlots);

            if (GUILayout.Button("Refresh Name")) {
                fields = SavedVariables.ReturnType();
            }
            if (GUILayout.Button("Delete All")) {
                areYouSureWindow = !areYouSureWindow;
            }

            if (numberOfSlots > 0) {
                GUILayout.BeginHorizontal();


                for (int x = 0; x < numberOfSlots; x++) {
                    GUILayout.BeginVertical();
                    //scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(Screen.width), GUILayout.Height(Screen.height - 50));
                    GUILayout.Label("Index : " + x);
                    for (int i = 0; i < fields.Count; i++) {

                        GUILayout.Label(fields[i].Name);
                        // start the menu for all the saved data

                        if (fields[i].FieldType == typeof(float)) {
                            float newFloat = 0;

                            newFloat = EditorGUILayout.FloatField(PlayerPrefs.GetFloat(fields[i].Name + x.ToString(), 0));

                            if (GUI.changed)
                                PlayerPrefs.SetFloat(fields[i].Name + x.ToString(), newFloat);
                        }
                        else if (fields[i].FieldType == typeof(int)) {
                            int newInt = 0;
                            newInt = EditorGUILayout.IntField(PlayerPrefs.GetInt(fields[i].Name + x.ToString(), 0));

                            if (GUI.changed)
                                PlayerPrefs.SetInt(fields[i].Name + x.ToString(), newInt);
                        }
                        else if (fields[i].FieldType == typeof(string)) {
                            string newString = "";
                            newString = EditorGUILayout.TextField(PlayerPrefs.GetString(fields[i].Name + x.ToString()));

                            if (GUI.changed)
                                PlayerPrefs.SetString(fields[i].Name + x.ToString(), newString);
                        }
                        else if (fields[i].FieldType == typeof(bool)) {
                            bool newBool = false;

                            newBool = EditorGUILayout.Toggle(PlayerPrefs.GetInt(fields[i].Name + x.ToString(), 0) == 1 ? true : false);
                            if (GUI.changed)
                                PlayerPrefs.SetInt(fields[i].Name + x.ToString(), newBool ? 1 : 0);
                        }
                        else if (fields[i].FieldType == typeof(double)) {
                            double newDouble = 0;
                            newDouble = EditorGUILayout.FloatField(PlayerPrefs.GetFloat(fields[i].Name + x.ToString(), 0));

                            if (GUI.changed)
                                PlayerPrefs.SetFloat(fields[i].Name + x.ToString(), (float)newDouble);
                        }
                        else if (fields[i].FieldType == typeof(Vector2)) {
                            Vector2 val = new Vector2(PlayerPrefs.GetFloat(fields[i].Name + x.ToString() + "x"), PlayerPrefs.GetFloat(fields[i].Name + x.ToString() + "y"));
                            GUILayout.Label("   X:");
                            val.x = EditorGUILayout.FloatField(PlayerPrefs.GetFloat(fields[i].Name + x.ToString() + "x", 0));
                            GUILayout.Label("   Y:");
                            val.y = EditorGUILayout.FloatField(PlayerPrefs.GetFloat(fields[i].Name + x.ToString() + "y", 0));

                            if (GUI.changed) {
                                PlayerPrefs.SetFloat(fields[i].Name + x.ToString() + "x", (float)val.x);
                                PlayerPrefs.SetFloat(fields[i].Name + x.ToString() + "y", (float)val.y);
                            }
                        }
                        else if (fields[i].FieldType == typeof(Vector3)) {
                            Vector3 val = new Vector3(PlayerPrefs.GetFloat(fields[i].Name + x.ToString() + "x"), PlayerPrefs.GetFloat(fields[i].Name + x.ToString() + "y"), PlayerPrefs.GetFloat(fields[i].Name + x.ToString() + "z"));
                            GUILayout.Label("   X:");
                            val.x = EditorGUILayout.FloatField(PlayerPrefs.GetFloat(fields[i].Name + x.ToString() + "x", 0));
                            GUILayout.Label("   Y:");
                            val.y = EditorGUILayout.FloatField(PlayerPrefs.GetFloat(fields[i].Name + x.ToString() + "y", 0));
                            GUILayout.Label("   Z:");
                            val.z = EditorGUILayout.FloatField(PlayerPrefs.GetFloat(fields[i].Name + x.ToString() + "z", 0));

                            if (GUI.changed) {
                                PlayerPrefs.SetFloat(fields[i].Name + x.ToString() + "x", (float)val.x);
                                PlayerPrefs.SetFloat(fields[i].Name + x.ToString() + "y", (float)val.y);
                                PlayerPrefs.SetFloat(fields[i].Name + x.ToString() + "z", (float)val.z);
                            }
                        }
                        else {
                            if (fields[i].FieldType == typeof(List<int>)) {
                                string newStringInt = "";
                                newStringInt = EditorGUILayout.TextField(PlayerPrefs.GetString(fields[i].Name + x.ToString()));

                                if (GUI.changed)
                                    PlayerPrefs.SetString(fields[i].Name + x.ToString(), newStringInt);
                            }
                            else if (fields[i].FieldType == typeof(List<bool>)) {
                                string newStringInt = "";
                                newStringInt = EditorGUILayout.TextField(PlayerPrefs.GetString(fields[i].Name + x.ToString()));

                                if (GUI.changed)
                                    PlayerPrefs.SetString(fields[i].Name + x.ToString(), newStringInt);
                            }
                            else if (fields[i].FieldType == typeof(List<float>)) {
                                string newStringInt = "";
                                newStringInt = EditorGUILayout.TextField(PlayerPrefs.GetString(fields[i].Name + x.ToString()));

                                if (GUI.changed)
                                    PlayerPrefs.SetString(fields[i].Name + x.ToString(), newStringInt);
                            }
                            else if (fields[i].FieldType == typeof(List<string>)) {
                                string newStringInt = "";
                                newStringInt = EditorGUILayout.TextField(PlayerPrefs.GetString(fields[i].Name + x.ToString()));

                                if (GUI.changed)
                                    PlayerPrefs.SetString(fields[i].Name + x.ToString(), newStringInt);
                            }
                            else if (fields[i].FieldType == typeof(List<double>)) {
                                string newStringInt = "";
                                newStringInt = EditorGUILayout.TextField(PlayerPrefs.GetString(fields[i].Name + x.ToString()));

                                if (GUI.changed)
                                    PlayerPrefs.SetString(fields[i].Name + x.ToString(), newStringInt);
                            }

                        }

                    }
                    //GUILayout.EndScrollView();
                    GUILayout.EndVertical();
                }

                GUILayout.EndHorizontal();

            }
            else if (numberOfSlots == 0) {
                scrollPosition = GUILayout.BeginScrollView(scrollPosition);
                for (int i = 0; i < fields.Count; i++) {
                    GUILayout.Label(fields[i].Name);

                    // start the menu for all the saved data
                    GUILayout.BeginHorizontal();

                    if (fields[i].FieldType == typeof(float)) {
                        float newFloat = 0;
                        newFloat = EditorGUILayout.FloatField(PlayerPrefs.GetFloat(fields[i].Name, 0));
                        if (GUI.changed)
                            PlayerPrefs.SetFloat(fields[i].Name, newFloat);
                    }
                    else if (fields[i].FieldType == typeof(int)) {
                        int newInt = 0;
                        newInt = EditorGUILayout.IntField(PlayerPrefs.GetInt(fields[i].Name, 0));

                        if (GUI.changed)
                            PlayerPrefs.SetInt(fields[i].Name, newInt);
                    }
                    else if (fields[i].FieldType == typeof(string)) {
                        string newString = "";
                        newString = EditorGUILayout.TextField(PlayerPrefs.GetString(fields[i].Name));

                        if (GUI.changed)
                            PlayerPrefs.SetString(fields[i].Name, newString);
                    }
                    else if (fields[i].FieldType == typeof(bool)) {
                        bool newBool = false;

                        newBool = EditorGUILayout.Toggle(PlayerPrefs.GetInt(fields[i].Name, 0) == 1 ? true : false);
                        if (GUI.changed)
                            PlayerPrefs.SetInt(fields[i].Name, newBool ? 1 : 0);
                    }
                    else if (fields[i].FieldType == typeof(double)) {
                        double newDouble = 0;
                        newDouble = EditorGUILayout.FloatField(PlayerPrefs.GetFloat(fields[i].Name, 0));

                        if (GUI.changed)
                            PlayerPrefs.SetFloat(fields[i].Name, (float)newDouble);
                    }
                    else if (fields[i].FieldType == typeof(Vector2)) {
                        Vector2 val = new Vector2(PlayerPrefs.GetFloat(fields[i].Name + "x"), PlayerPrefs.GetFloat(fields[i].Name + "y"));
                        GUILayout.Label("X:");
                        val.x = EditorGUILayout.FloatField(PlayerPrefs.GetFloat(fields[i].Name + "x", 0));
                        GUILayout.Label("Y:");
                        val.y = EditorGUILayout.FloatField(PlayerPrefs.GetFloat(fields[i].Name + "y", 0));

                        if (GUI.changed) {
                            PlayerPrefs.SetFloat(fields[i].Name + "x", (float)val.x);
                            PlayerPrefs.SetFloat(fields[i].Name + "y", (float)val.y);
                        }
                    }
                    else if (fields[i].FieldType == typeof(Vector3)) {
                        Vector3 val = new Vector3(PlayerPrefs.GetFloat(fields[i].Name + "x"), PlayerPrefs.GetFloat(fields[i].Name + "y"), PlayerPrefs.GetFloat(fields[i].Name + "z"));
                        GUILayout.Label("X:");
                        val.x = EditorGUILayout.FloatField(PlayerPrefs.GetFloat(fields[i].Name + "x", 0));
                        GUILayout.Label("Y:");
                        val.y = EditorGUILayout.FloatField(PlayerPrefs.GetFloat(fields[i].Name + "y", 0));
                        GUILayout.Label("Z:");
                        val.z = EditorGUILayout.FloatField(PlayerPrefs.GetFloat(fields[i].Name + "z", 0));

                        if (GUI.changed) {
                            PlayerPrefs.SetFloat(fields[i].Name + "x", (float)val.x);
                            PlayerPrefs.SetFloat(fields[i].Name + "y", (float)val.y);
                            PlayerPrefs.SetFloat(fields[i].Name + "z", (float)val.z);
                        }
                    }
                    else {
                        if (fields[i].FieldType == typeof(List<int>)) {
                            string newStringInt = "";
                            newStringInt = EditorGUILayout.TextField(PlayerPrefs.GetString(fields[i].Name));

                            if (GUI.changed)
                                PlayerPrefs.SetString(fields[i].Name, newStringInt);
                        }
                        else if (fields[i].FieldType == typeof(List<bool>)) {
                            string newStringInt = "";
                            newStringInt = EditorGUILayout.TextField(PlayerPrefs.GetString(fields[i].Name));

                            if (GUI.changed)
                                PlayerPrefs.SetString(fields[i].Name, newStringInt);
                        }
                        else if (fields[i].FieldType == typeof(List<float>)) {
                            string newStringInt = "";
                            newStringInt = EditorGUILayout.TextField(PlayerPrefs.GetString(fields[i].Name));

                            if (GUI.changed)
                                PlayerPrefs.SetString(fields[i].Name, newStringInt);
                        }
                        else if (fields[i].FieldType == typeof(List<string>)) {
                            string newStringInt = "";
                            newStringInt = EditorGUILayout.TextField(PlayerPrefs.GetString(fields[i].Name));

                            if (GUI.changed)
                                PlayerPrefs.SetString(fields[i].Name, newStringInt);
                        }
                        else if (fields[i].FieldType == typeof(List<double>)) {
                            string newStringInt = "";
                            newStringInt = EditorGUILayout.TextField(PlayerPrefs.GetString(fields[i].Name));

                            if (GUI.changed)
                                PlayerPrefs.SetString(fields[i].Name, newStringInt);
                        }
                    }

                    GUILayout.EndHorizontal();
                }

                GUILayout.EndScrollView();
            }
        }
    }
}