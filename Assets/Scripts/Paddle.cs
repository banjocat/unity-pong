using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	public float speed = 10f;

	private bool _blockUp = false;
	private bool _blockDown = false;
	private Rigidbody2D rb2D;


	protected void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}
	protected void Move(int yDir)
	{
		var velocity = rb2D.velocity;
		if (yDir == 0 || _blockDown && yDir < 0 || _blockUp && yDir > 0)
			velocity.y = 0;
		else
			velocity.y = speed * yDir;
		rb2D.velocity = velocity;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag(("Wall"))) return;
		var position = transform.position;
		var renderer = GetComponent<Renderer>();
		var halfYSize = renderer.bounds.size.y / 2.0f;
		var newY = other.bounds.center.y;
		if (position.y <= 0)
		{
			_blockDown = true;
			newY += halfYSize;
		}
		else
		{
			_blockUp = true;
			newY -= halfYSize;
		}
		position.y = newY;
		transform.position = position;

	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (!other.CompareTag("Wall")) return;
		_blockUp = false;
		_blockDown = false;
	}
}
