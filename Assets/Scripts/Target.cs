using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public GameObject missile;

	void Start() {
		spriteRenderer.color = missile.GetComponent<SpriteRenderer>().color;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject == missile) {
	    	Destroy(this.gameObject);

	    	if (GameObject.FindGameObjectsWithTag("Target").Length == 1) {
				Application.LoadLevel(Application.loadedLevel+1);
	    	}
		}
	}
}
