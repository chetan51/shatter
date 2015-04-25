using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Rigidbody2D rigidbodyComponent;

	public float forceMultiplier = 2;
	public float rotationMultiplier = 200;

	public void AddForce(Vector2 force) {
		rigidbodyComponent.AddForce(force * forceMultiplier);
		rigidbodyComponent.angularVelocity = force.magnitude * rotationMultiplier;
	}

	IEnumerator CheckSolved() {
		yield return new WaitForSeconds(0.5f);
	    if (GameObject.FindGameObjectsWithTag("Target").Length == 0) {
			Application.LoadLevel(Application.loadedLevel+1);
	    }
	}

	void OnCollisionEnter2D(Collision2D collision) {
    	Application.LoadLevel(Application.loadedLevel);
	}

	void OnTriggerEnter2D(Collider2D other) {
		Target target = other.gameObject.GetComponent<Target>();

		if (target != null && target.projectile == this.gameObject) {
	    	target.Destroy();
	    }

	    StartCoroutine(CheckSolved());
	}

}
