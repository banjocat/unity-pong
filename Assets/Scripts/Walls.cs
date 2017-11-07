using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
	// Use this for initialization
	public GameObject court;
	void Start ()
	{
		var crt = GetCourtVertices();
		CreateCollider(crt[0].x, crt[0].y, crt[1].x, crt[0].y);
		CreateCollider(crt[0].x, crt[1].y, crt[1].x, crt[1].y);
	}

	Vector3[] GetCourtVertices()
	{
		court = GameObject.FindGameObjectWithTag("Court");
		var renderer = court.GetComponent<SpriteRenderer>();
		var vertices = new Vector3[2];
		vertices[0] = renderer.bounds.min;
		vertices[1] = renderer.bounds.max;
		Debug.Log(vertices[0]);
		Debug.Log(vertices[1]);
		return vertices;
	}

	void CreateCollider(float x1, float y1, float x2, float y2)
	{
		var collider = gameObject.AddComponent<EdgeCollider2D>();
		var points = new List<Vector2>();
		points.Add(new Vector2(x1, y1));
		points.Add(new Vector2(x2, y2));
		collider.points = points.ToArray();
		collider.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
