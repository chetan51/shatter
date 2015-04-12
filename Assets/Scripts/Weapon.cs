using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Renderer rd;
	public Transform projectilePrefab;

	public void Shoot() {
		Transform projectile = Instantiate(projectilePrefab) as Transform;

		Vector3 position;
		position = transform.position;
		position.y += rd.bounds.size.y / 2;

		projectile.position = position;
	}
}
