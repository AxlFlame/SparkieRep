﻿using UnityEngine;
using System.Collections;

public class OilDropControl : MonoBehaviour {
	public int fallSpeed;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 0.9f);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position.y -= 1;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
