using UnityEngine;
using System.Collections;

public class DoorUnlock : MonoBehaviour {
	public GameObject bigDoor;
	public GameObject puzzleBox;
	public GameObject magnetizer;
	public Vector3 doorPos;
	public bool liftDoor;
	// Use this for initialization
	void Start () {
		doorPos = bigDoor.GetComponent<Transform> ().position;
	}
	
	// Update is called once per frame
	void Update () {
		doorPos = bigDoor.GetComponent<Transform> ().position;
		if (liftDoor)
		{
			doorPos.y += 0.05f;
			bigDoor.GetComponent<Transform> ().position = doorPos;
			if (doorPos.y >= 20)
			{
				doorPos.y = 20;
				bigDoor.GetComponent<Transform> ().position = doorPos;
				//liftDoor = false;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "PuzzleBox")
		{
			magnetizer.GetComponent<MagnetizeSkill>().isConnectedToBox = false;
			liftDoor = true;
		}
	}
}
