using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision) {
    	Destroy(this.gameObject);
	}
}
