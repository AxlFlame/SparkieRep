﻿using UnityEngine;
using System.Collections;

public class TitleGUI : MonoBehaviour {
	public GUISkin titleSkin;
	public GUIStyle titleStyle;
	public Texture2D background, LOGO;
	public bool DragWindow = false;   
	public string levelToLoadWhenClickedPlay = ""; 
	public string[] aboutLines = new string[3];
	public Texture2D pressStart;
	
	private string clicked = "", MessageDisplayOnAbout;
	private Rect WindowRect = new Rect((Screen.width / 2) - 210, Screen.height / 2 + 300, 420, 114);
	private Rect WindowRect2 = new Rect((Screen.width / 2) - 100, Screen.height / 2, 200, 165);
	private float volume = 1.0f;

	// Use this for initialization
	void Start () {
		MessageDisplayOnAbout = "Sparkie";
		MessageDisplayOnAbout += "\n"; 
		aboutLines [0] = "Jogo em desenvolvimento por Yuri Guzon Mainka";
		
		//print (aboutLines.Length);
		
		
		if (PlayerPrefs.GetFloat ("Audio Level") < 1) 
		{
			volume = PlayerPrefs.GetFloat ("Audio Level");   
		}
		else
		{
			volume = 1.0f;
		}
		
		for (int x = 0; x < aboutLines.Length;x++ )
		{
			MessageDisplayOnAbout += aboutLines[x] + " \n ";
		}
		MessageDisplayOnAbout += "\n Pressione Esc para retornar ao Menu Principal.";

		levelToLoadWhenClickedPlay = "MainMenu";
	}

	void OnGUI(){
		if (background != null)
			GUI.DrawTexture(new Rect(0,0,Screen.width , Screen.height),background);
		if (LOGO != null && clicked != "about")
			GUI.DrawTexture(new Rect((Screen.width / 2) - 100, 30, 200, 200), LOGO);
		
		GUI.skin = titleSkin;
		if (clicked == "")
		{
			if (GUI.Button(WindowRect, pressStart, titleStyle))
			{
				AutoFade.LoadLevel(levelToLoadWhenClickedPlay,2,1,Color.black);
			}
		}
	}
}
