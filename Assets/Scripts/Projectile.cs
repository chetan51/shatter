using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Rigidbody2D rigidbodyComponent;

	public void AddForce(Vector2 force) {
		rigidbodyComponent.AddForce(force);
		rigidbodyComponent.angularVelocity = force.magnitude * 100;
	}

	void OnCollisionEnter2D(Collision2D collision) {
    	Application.LoadLevel(Application.loadedLevel);
	}

	void OnTriggerEnter2D(Collider2D other) {
		Target target = other.gameObject.GetComponent<Target>();

		if (target != null && target.projectile == this.gameObject) {
	    	target.Destroy();
	    }

    	if (GameObject.FindGameObjectsWithTag("Target").Length == 1) {
    		NextLevel();
    	}
	}

	IEnumerator NextLevel() {
		yield return new WaitForSeconds(1.0f);
		Application.LoadLevel(Application.loadedLevel+1);
	}

}
