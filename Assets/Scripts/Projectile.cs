using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Rigidbody2D rb;
	public Vector2 speed = new Vector2(0, 3);

	private Vector2 movement = new Vector2(0, 0);

	void Start () {
		movement.y = speed.y;
	}

	void FixedUpdate () {
		rb.velocity = movement;
	}

	void OnBecameInvisible() {
		Destroy(this.gameObject);
	}
}
