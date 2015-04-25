using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public GameObject projectile;
	public ParticleSystem particleSystemComponent;
	public GameObject forcefield;

	public float destroyDuration = 0.5f;
	public float destroyTime = 0f;

	public void Destroy() {
		DestroyForcefield();
		particleSystemComponent.Play();
		spriteRenderer.enabled = false;
	}

	void DestroyForcefield() {
		forcefield.GetComponent<BoxCollider2D>().enabled = false;
		forcefield.GetComponent<SpriteRenderer>().enabled = false;
		// AnimateDestroyForceField();
	}

	// IEnumerator AnimateDestroyForcefield() {
	// 	destroyTime += Time.deltaTime;
	// 	forcefield.localScale -= new Vector3()
	// 	yield return null;
	// }

	void Start() {
		spriteRenderer.color = projectile.GetComponent<SpriteRenderer>().color;
		particleSystemComponent.startColor = spriteRenderer.color;
	}

}
