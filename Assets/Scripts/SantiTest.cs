using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class SantiTest : NetworkBehaviour
{

	public float speed = 10.0f;
	//public static bool player1 = true;
	void Start()
	{	/*
		if(player1)
		{
			transform.position = new Vector3(-220, 158, 0);
			player1 = false;
		}
		else
			transform.position = new Vector3(220, 158, 0);
		*/

	}

	void Update()
	{

		// Get the horizontal and vertical axis.
		// By default they are mapped to the arrow keys.
		// The value is in the range -1 to 1
		if(!isLocalPlayer)
			return;

		float translation = Input.GetAxis("Vertical") * speed;
		float t = Input.GetAxis("Horizontal") * speed;


		// Make it move 10 meters per second instead of 10 meters per frame...
		translation *= Time.deltaTime;
		t *= Time.deltaTime;

		// Move translation along the object's z-axis
		transform.Translate(t, translation, 0);

	}
}
