using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

	public Vector2 speed = new Vector2 (3, -1);

	private Rigidbody2D rb;
	private Vector2 movement = new Vector2 (0, 0);
	private Vector3 lastPosition;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		movement.y = speed.y;
		lastPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {
		// Calculate horizontal movement
		Vector2 mousePosition = Input.mousePosition;
		mousePosition.x = Math.Min (Math.Max (mousePosition.x, 0), Screen.width);
		Vector2 target = Camera.main.ScreenToWorldPoint (mousePosition);
		movement.x = (target.x - rb.position.x) * speed.x;

		// Update camera position
		Vector3 position = Camera.main.transform.position;
		position.y += transform.position.y - lastPosition.y;
		Camera.main.transform.position = position;
		lastPosition = transform.position;
	}

	void FixedUpdate () {
		rb.velocity = movement;
	}
}
