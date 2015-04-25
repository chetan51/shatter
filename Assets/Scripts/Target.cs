using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public GameObject projectile;

	void Start() {
		spriteRenderer.color = projectile.GetComponent<SpriteRenderer>().color;
	}

}
