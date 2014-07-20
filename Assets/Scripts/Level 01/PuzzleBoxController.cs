using UnityEngine;
using System.Collections;

public class PuzzleBoxController : MonoBehaviour {
	public bool isEnabled = false;
	private float sparkieX;
	public GameObject player;
	public Vector3 boxPos;
	// Use this for initialization
	void Start () {
		boxPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (isEnabled)
		{
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
			sparkieX = player.GetComponent<Transform>().position.x;
			boxPos.x = sparkieX;
			boxPos.y = -8f;
			transform.position = boxPos;
		}
		else
		{
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
		}
	}
}
