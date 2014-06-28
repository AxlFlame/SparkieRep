using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
	#region Static registers
	public static Timer StartTimer(GameObject target){
		Timer obj = target.GetComponent<Timer>();
		if(obj == null){
			obj = target.AddComponent<Timer>();
		}
		obj.StartTimer();
		return obj;
	}
	public static void ResetTimer(GameObject target){
		Timer obj = target.GetComponent<Timer>();
		if(obj != null){
			obj.ResetTimer();
		}
	}
	
	public static void StopTimer(GameObject target){
		Timer obj = target.GetComponent<Timer>();
		if(obj != null){
			obj.StopTimer();
		}
	}
	#endregion
	
	private bool timerIsActive = false;
	public float timeActive;
	public string niceTime;
	public void StartTimer(){
		timerIsActive = true;
		timeActive = 0f;
	}

	void Start()
	{
		StartTimer ();
	}
	
	// Update is called once per frame
	void Update () {
		if(timerIsActive){
			timeActive += Time.deltaTime;
		}
	}

	void OnGUI (){
		int minutes = Mathf.FloorToInt(timeActive / 60F);
		int seconds = Mathf.FloorToInt(timeActive - minutes * 60);
		
		niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

		guiText.text = ("Timer: " + niceTime); 
	}
	
	public float GetCurrentTime(){
		return timeActive;
	}
	
	public string GetCurrentTimeString(){
		return timeActive.ToString("00.00");
	}
	public bool IsTimerRunning(){
		return timerIsActive;
	}
	public void StopTimer(){
		timerIsActive = false;
	}
	public void ResetTimer(){
		timeActive = 0f;
	}
}