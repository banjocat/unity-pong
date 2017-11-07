using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

	public float speed = 5f;
	public Vector2 direction;
	public float speedIncreasePerHit = .2f;

	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = speed * direction;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (!other.CompareTag("Court")) return;
		if (transform.position.x < 0)
			GameData.Score("left");
		else
			GameData.Score("right");
	}

	public static void ResetBall()
	{
		var ball = GameObject.Find("ball");
		var position = new Vector2(0, 0);
		ball.transform.position = position;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Paddle"))
		{
			direction.x = direction.x * -1f;
			speed += speedIncreasePerHit;
		}

		if (other.CompareTag("Wall"))
		{
			direction.y = direction.y * -1f;
		}
		rb2d.velocity = speed * direction;
	}
}
