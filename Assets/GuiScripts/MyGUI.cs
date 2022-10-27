using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGUI : MonoBehaviour
{
    private string _massage; 
    public GUISkin test;
    private Rect buttonRect;
    public Texture2D _icon;



    void OnGUI()
    {
        buttonRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 70, 200, 140);
        GUI.skin = test;

        GUI.Box(buttonRect, "Main Menu");
        if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 35, 180, 30), "Open"))
        {
            _massage = "Open";
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 0, 180, 30), "Save"))
            _massage = "Save";

        if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 35, 180, 30), "Load"))
            _massage = "Load";

        GUI.Label(new Rect(220, 10, 100, 30), _massage);

        GUI.BeginGroup(new Rect(Screen.width / 2 - 25, 10, 200, 200));
        GUI.Label(new Rect(0, 0, 50, 20), "HP = 100");
        GUI.EndGroup();
    }
}
