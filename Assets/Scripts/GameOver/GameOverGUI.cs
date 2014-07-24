using UnityEngine;
using System.Collections;

public class GameOverGUI : MonoBehaviour {
	public GUIStyle titleStyle;
	public Texture2D background, LOGO, mainMenuTexture;
	public bool DragWindow = false;   
	public string levelToLoadWhenClickedPlay = ""; 
	public string[] aboutLines = new string[3];
	
	private string clicked = "", MessageDisplayOnAbout;
	private Rect mainMenuRect = new Rect((Screen.width / 2) - 210, Screen.height / 2 - 130, 420, 114);
	private Rect WindowRect2 = new Rect((Screen.width / 2) - 200, Screen.height / 2 - 300, 400, 165);
	private Rect playAgainRect = new Rect((Screen.width / 2) - 75, Screen.height / 2 - 200, 150, 50);
	
	// Use this for initialization
	void Start () {
		MessageDisplayOnAbout = "";
		MessageDisplayOnAbout += "\n"; 
		aboutLines [0] = "Oh, não! Você perdeu. Quer tentar novamente?";
		
		//print (aboutLines.Length);
		
		for (int x = 0; x < aboutLines.Length;x++ )
		{
			MessageDisplayOnAbout += aboutLines[x] + " \n ";
		}
		
		levelToLoadWhenClickedPlay = "Level01F";
	}
	
	void Update()
	{
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			Application.LoadLevel("MainMenu");
		}
	}
	
	void OnGUI(){
		if (background != null)
			GUI.DrawTexture(new Rect(0,0,Screen.width , Screen.height),background);
		if (LOGO != null && clicked != "about")
			GUI.DrawTexture(new Rect((Screen.width / 2) - 100, 30, 200, 200), LOGO);
		
		if (clicked == "")
		{
			GUI.Box(WindowRect2, MessageDisplayOnAbout);
			if (GUI.Button (playAgainRect, "Jogar Novamente.")) {
				Application.LoadLevel("Level01F");
			}
			if (GUI.Button(mainMenuRect, mainMenuTexture, titleStyle))
			{
				Application.LoadLevel("MainMenu");
			}
		}
	}
}
