using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D otherCollider) {
		Projectile projectile = otherCollider.gameObject.GetComponent<Projectile>();
	    if (projectile != null) {
	    	Destroy(projectile.gameObject);
	    	Destroy(this.gameObject);
		}
	}
}
