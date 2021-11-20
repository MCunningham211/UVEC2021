using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static int Player1Score = 0;
    public static int Player2Score = 0;
    private static bool started = false;

    public GUISkin layout;

    // Start is called before the first frame update
    void Start() {
    }
    
    public void Score1 () {
        Player1Score++;
    }
    public void Score2 () {
        Player2Score++;
    }

private GUIStyle guiStyle = new GUIStyle(); //create a new variable
    void OnGUI() {
        guiStyle.fontSize = 20; //change the font size
        Rect startButtonRect = new Rect(Screen.width / 2 - 35, 20, 120, 53);
        GUI.Label(new Rect((Screen.width / 2) - 138, 20, 100, 100), "Player 1: " + Player1Score, guiStyle);
        GUI.Label(new Rect((Screen.width / 2) + 162, 20, 100, 100), "Player 2: " + Player2Score, guiStyle);
    }
}
