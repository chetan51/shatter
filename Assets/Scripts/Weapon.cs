using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Renderer rd;
	public Transform projectilePrefab;
	public TextMesh text;
	public int numProjectiles = 3;

	public void Shoot() {
		if (numProjectiles == 0) {
			return;
		}

		Transform projectile = Instantiate(projectilePrefab) as Transform;

		Vector3 position;
		position = transform.position;
		position.y += rd.bounds.size.y / 2;

		projectile.GetComponent<Projectile>().weapon = this;
		projectile.position = position;
		numProjectiles--;
	}

	public void Update() {
		text.text = numProjectiles.ToString();
		text.color = Color.black;
		if (numProjectiles == 0) {
			text.color = Color.red;
		}
	}
}
