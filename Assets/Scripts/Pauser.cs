using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {
	private bool paused = false;
	public GUIStyle pauseStyle;
	public Texture2D background, resumeTexture, musicTexture, soundTexture, mainMenuTexture;
	private Rect resumeRect = new Rect((Screen.width / 2) - 210, Screen.height / 2 - 300, 420, 114);
	private Rect musicRect = new Rect((Screen.width / 2) - 210, Screen.height / 2 - 190, 420, 114);
	private Rect soundRect = new Rect((Screen.width / 2) - 210, Screen.height / 2 - 80, 420, 114);
	private Rect mainMenuRect = new Rect((Screen.width / 2) - 210, Screen.height / 2 + 30, 420, 114);
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			paused = !paused;
		}

		if(paused)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}

	void OnGUI()
	{
		if (paused)
		{
			GUI.DrawTexture(new Rect(0,0,Screen.width , Screen.height),background);
			if (GUI.Button(resumeRect, resumeTexture, pauseStyle))
			{
				paused = !paused;
			}
			if (GUI.Button(musicRect, musicTexture, pauseStyle))
			{

			}
			if (GUI.Button(soundRect, soundTexture, pauseStyle))
			{

			}
			if (GUI.Button(mainMenuRect, mainMenuTexture, pauseStyle))
			{
				paused = !paused;
				AutoFade.LoadLevel("MainMenu",2,1,Color.black);
			}
		}
	}
}
