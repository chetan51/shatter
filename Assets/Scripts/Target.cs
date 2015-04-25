using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public GameObject projectile;

	void Start() {
		spriteRenderer.color = projectile.GetComponent<SpriteRenderer>().color;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject == projectile) {
	    	Destroy(this.gameObject);

	    	if (GameObject.FindGameObjectsWithTag("Target").Length == 1) {
				Application.LoadLevel(Application.loadedLevel+1);
	    	}
		}
	}
}
