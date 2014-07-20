using UnityEngine;
using System.Collections;

public class LevelComplete : MonoBehaviour {

	//Referencias
	public bool isLevelC = false;
	public GameObject score;
	public int completeScreenWidth = 350;
	public int completeScreenHeight = 250;
	public int timeTextWidth = 175;
	public int timeTextHeight = 25;
	private Rect WindowRect = new Rect((Screen.width / 2) - 100, Screen.height / 2 + 60, 200, 65);

	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if(col.gameObject.tag == "Player")
		{
			// .. stop the camera tracking the player
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;
			
			// .. stop the Health Bar following the player
			if(GameObject.FindGameObjectWithTag("HealthBar").activeSelf)
			{
				GameObject.FindGameObjectWithTag("HealthBar").SetActive(false);
			}
			// ... destroy the player.
			Destroy (col.gameObject);
			// ... reload the level.
			//StartCoroutine("ReloadGame");
		}

		isLevelC = true;
	}
	
	//IEnumerator ReloadGame()
	//{			
		// ... pause briefly
		//yield return new WaitForSeconds(2);
		// ... and then reload the level.
		//Application.LoadLevel(Application.loadedLevel);
	//}

	void OnGUI()
	{
		if (isLevelC) {
			string timerT = score.GetComponent<Timer>().niceTime;

			Rect completeScreenRect = new Rect(Screen.width/2 - (completeScreenWidth/2), Screen.height/2 - (completeScreenHeight/2), completeScreenWidth, completeScreenHeight);
			Rect TimerTextRect = new Rect(Screen.width/2 - (timeTextWidth - 5), (Screen.height/2 - 70) - (timeTextHeight/2), timeTextWidth, timeTextHeight);
			Rect HighSRect = new Rect(Screen.width/2 - (timeTextWidth - 5), (Screen.height/2 - 35) - (timeTextHeight/2), timeTextWidth, timeTextHeight);
			GUI.Box (completeScreenRect, "Você completou a primeira fase!");
			GUI.TextField(TimerTextRect, "Seu tempo foi: " + timerT);
			GUI.TextField(HighSRect, "Seu melhor tempo é: " + timerT);

			Time.timeScale = 0;
	
			//Go to next level
			//if (GUI.Button (new Rect (Screen.width*7/20,Screen.height*3/8 ,Screen.width/3 ,Screen.height/8),gonextLevel)) 
			//{
			//	Time.timeScale = 1;
			//	Application.LoadLevel(currlevel+1);
			//	print("next level");
			//}
	
			//Play this level again/Refresh
			if (GUI.Button (new Rect (Screen.width/2 - 75, completeScreenRect.y + completeScreenRect.height/2, 150, 40), "Jogar Novamente?")) {
					Time.timeScale = 1;
					Application.LoadLevel (Application.loadedLevel);
			}
			if (GUI.Button (WindowRect, "Finalizar Demo")) {
				Time.timeScale = 1;
				Application.LoadLevel ("GameFinish");
			}
		}
	}

}