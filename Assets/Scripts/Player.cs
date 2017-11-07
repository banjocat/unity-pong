using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Paddle
{

	public KeyCode upKey;

	public KeyCode downKey;
	// Update is called once per frame
	void FixedUpdate ()
	{
		Move((int)Input.GetAxisRaw("Vertical"));
	}
}
