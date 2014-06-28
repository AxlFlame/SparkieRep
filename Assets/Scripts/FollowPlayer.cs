using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
	public Vector3 offset;			// The offset at which the Health Bar follows the player.

	public Vector3 scaleset;
	
	private Transform player;		// Reference to the player.
	
	
	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;

	}
	
	void Update ()
	{
		//offset.x = -37;
		//offset.y = 1;
		//offset.z = -1;
		
		//scaleset.x = 2;
		//scaleset.y = 2;
		//scaleset.z = 1;

		// Set the position to the player's position with the offset.
		transform.position = player.position + offset;
		//transform.localScale = scaleset;
	}
}