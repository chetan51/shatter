using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

	public Rigidbody2D rb;
	public Weapon weapon;
	public Vector2 speed = new Vector2(3, 1);
	public float stationaryTimeScale = 0.15f;
	public float movingTimeScale = 1.0f;

	private Vector2 movement = new Vector2(0, 0);
	private Vector2 target = new Vector2(0, 0);
	private Vector3 lastPosition;

	void Start () {
		movement.y = speed.y;
		lastPosition = transform.position;
	}

	void Update () {
		Time.timeScale = stationaryTimeScale;

		if (Input.GetMouseButton(0)) {
			// Calculate new target
			Vector2 mousePosition = Input.mousePosition;
			mousePosition.x = Math.Min (Math.Max (mousePosition.x, 0), Screen.width);
			target = Camera.main.ScreenToWorldPoint (mousePosition);

			Time.timeScale = movingTimeScale;
		}
		if (Input.GetMouseButtonDown(1)) {
			// Shoot projectile
			weapon.Shoot();
		}

		// Calculate horizontal movement
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

	void OnTriggerEnter2D(Collider2D otherCollider) {
		Target target = otherCollider.gameObject.GetComponent<Target>();
	    if (target != null) {
	    	Application.LoadLevel(Application.loadedLevel);
	    }
	}
}
