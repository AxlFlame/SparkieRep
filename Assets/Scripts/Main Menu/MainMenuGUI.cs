using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {
	public GUIStyle titleStyle;
	public Texture2D background, LOGO, newGameTexture, loadGameTexture, optionsTexture, exitTexture;
	public bool DragWindow = false;   
	public string levelToLoadWhenClickedPlay = ""; 
	public string[] aboutLines = new string[3];
	public Texture2D pressStart;
	
	private string clicked = "", MessageDisplayOnAbout;
	private Rect newGameRect = new Rect((Screen.width / 2) - 470, Screen.height / 2 - 150, 420, 114);
	private Rect loadGameRect = new Rect((Screen.width / 2) - 510, Screen.height / 2, 420, 114);
	private Rect optionsRect = new Rect((Screen.width / 2) - 550, Screen.height / 2 + 150, 420, 114);
	private Rect exitRect = new Rect((Screen.width / 2) - 590, Screen.height / 2 + 300, 420, 114);
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
		
		levelToLoadWhenClickedPlay = "Level01F";
	}
	
	void OnGUI(){
		if (background != null)
			GUI.DrawTexture(new Rect(0,0,Screen.width , Screen.height),background);
		if (LOGO != null && clicked != "about")
			GUI.DrawTexture(new Rect((Screen.width / 2) - 100, 30, 200, 200), LOGO);

		if (clicked == "")
		{
			if (GUI.Button(newGameRect, newGameTexture, titleStyle))
			{
				AutoFade.LoadLevel(levelToLoadWhenClickedPlay,2,1,Color.black);
			}
			if (GUI.Button(loadGameRect, loadGameTexture, titleStyle))
			{
				AutoFade.LoadLevel(levelToLoadWhenClickedPlay,2,1,Color.black);
			}
			if (GUI.Button(optionsRect, optionsTexture, titleStyle))
			{
				clicked = "options";
			}
			if (GUI.Button(exitRect, exitTexture, titleStyle))
			{
				Application.Quit();
			}
		}
		else if (clicked == "options")
		{
			WindowRect2 = GUI.Window(1, WindowRect2, optionsFunc, "Options");
		}
		else if (clicked == "about")
		{
			GUI.Box(new Rect (0,0,Screen.width,Screen.height), MessageDisplayOnAbout);
		}
	}
	
	private void optionsFunc(int id)
	{
		GUILayout.Box("Volume");
		volume = GUILayout.HorizontalSlider(volume ,0.0f,1.0f);
		AudioListener.volume = volume;
		PlayerPrefs.SetFloat ("Audio Level", volume);
		
		if (GUILayout.Button("Erase Data")) 
		{
			PlayerPrefs.DeleteAll();
			levelToLoadWhenClickedPlay = "Level01F";
		}
		
		if (GUILayout.Button("Back")) 
		{
			clicked = "";
		}
		if (DragWindow)
			GUI.DragWindow(new Rect (0,0,Screen.width,Screen.height));
	}
	
	private void menuFunc(int id)
	{
		//buttons 
		if (GUILayout.Button("Start"))
		{
			//play game is clicked
			//Application.LoadLevel(levelToLoadWhenClickedPlay);
			AutoFade.LoadLevel(levelToLoadWhenClickedPlay,2,1,Color.black);
		}
		if (GUILayout.Button("Options"))
		{
			clicked = "options";
		}
		if (GUILayout.Button("About"))
		{
			clicked = "about";
		}
		if (GUILayout.Button("Exit"))
		{
			Application.Quit();
		}
		if (DragWindow)
			GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
	}
	
	// Update is called once per frame
	void Update () {
		if (clicked == "about" && Input.GetKey (KeyCode.Escape))
			clicked = "";
	}
}
