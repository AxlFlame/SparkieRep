using UnityEngine;
using System.Collections;

public class PuzzleBoxController : MonoBehaviour {
	public bool isEnabled = false;
	private float sparkieX;
	public GameObject player;
	public Vector3 boxPos;
	public Quaternion boxRot;
	// Use this for initialization
	void Start () {
		boxPos = transform.position;
		boxRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (isEnabled)
		{
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
			sparkieX = player.GetComponent<Transform>().position.x;
			boxPos.x = sparkieX;
			boxPos.y = -5.7f;
			boxRot.z = 0;

			transform.position = boxPos;
			transform.rotation = boxRot;
		}
		else
		{
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
		}
	}
}
