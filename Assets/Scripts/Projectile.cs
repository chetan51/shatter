using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Rigidbody2D rigidbodyComponent;

	public void AddForce(Vector2 force) {
		rigidbodyComponent.AddForce(force);
		rigidbodyComponent.angularVelocity = force.magnitude * 100;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Target target = collision.gameObject.GetComponent<Target>();
		if (target != null && target.projectile == this.gameObject) {
			return;
		}

    	Application.LoadLevel(Application.loadedLevel);
	}

}
