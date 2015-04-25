using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public GameObject projectile;
	public GameObject forcefield;

	public float destroyDuration = 0.5f;
	public float destroyTime = 0f;

	public void Destroy() {
		DestroyForcefield();
		CreateExplosion();
		Destroy(gameObject);
	}

	void DestroyForcefield() {
		// AnimateDestroyForceField();
	}

	// IEnumerator AnimateDestroyForcefield() {
	// 	destroyTime += Time.deltaTime;
	// 	forcefield.localScale -= new Vector3()
	// 	yield return null;
	// }

	void CreateExplosion() {
		GameObject explosion = Instantiate(Resources.Load("TargetExplosion")) as GameObject;
		explosion.transform.position = transform.position;
		ParticleSystem particleSystemComponent = explosion.GetComponent<ParticleSystem>();
		particleSystemComponent.startColor = spriteRenderer.color;
		particleSystemComponent.Play();
	}

	void Start() {
		spriteRenderer.color = projectile.GetComponent<SpriteRenderer>().color;
	}

}
