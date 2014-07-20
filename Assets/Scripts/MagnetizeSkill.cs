using UnityEngine;
using System.Collections;

public class MagnetizeSkill : MonoBehaviour {
	public GameObject puzzleBox;
	public bool isConnectedToBox = false;

	// Update is called once per frame
	void Update () {
		if (isConnectedToBox)
		{
			puzzleBox.GetComponent<PuzzleBoxController>().isEnabled = true;
		}
		else
		{
			puzzleBox.GetComponent<PuzzleBoxController>().isEnabled = false;
		}
		if (gameObject.GetComponent<CircleCollider2D>().enabled == false)
		{
			isConnectedToBox = false;
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if(col.gameObject.tag == "PuzzleBox")
		{
			isConnectedToBox = true;
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if(col.gameObject.tag == "PuzzleBox")
		{
			isConnectedToBox = false;
		}
	}
}
