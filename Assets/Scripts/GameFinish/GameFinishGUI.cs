using UnityEngine;
using System.Collections;

public class GameFinishGUI : MonoBehaviour {
	public GUIStyle titleStyle;
	public Texture2D background, LOGO, mainMenuTexture;
	public bool DragWindow = false;   
	public string levelToLoadWhenClickedPlay = ""; 
	public string[] aboutLines = new string[3];
	public Texture2D pressStart;
	
	private string clicked = "", MessageDisplayOnAbout;
	private Rect mainMenuRect = new Rect((Screen.width / 2) - 210, Screen.height / 2 + 350, 420, 114);
	private Rect WindowRect2 = new Rect((Screen.width / 2) - 200, Screen.height / 2 - 300, 400, 165);

	// Use this for initialization
	void Start () {
		MessageDisplayOnAbout = "";
		MessageDisplayOnAbout += "\n"; 
		aboutLines [0] = "Parabéns! Você terminou a demo de Sparkie!";
		
		//print (aboutLines.Length);
		
		for (int x = 0; x < aboutLines.Length;x++ )
		{
			MessageDisplayOnAbout += aboutLines[x] + " \n ";
		}
		MessageDisplayOnAbout += "\n Pressione Esc para retornar ao Menu Principal.";
		
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
			if (GUI.Button(mainMenuRect, mainMenuTexture, titleStyle))
			{
				Application.LoadLevel("MainMenu");
			}
		}
	}
}
