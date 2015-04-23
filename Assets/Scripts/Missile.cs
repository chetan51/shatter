using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	public Rigidbody2D rigidbodyComponent;
	public SpriteRenderer spriteRenderer;
	public LineRenderer lineRenderer;

	public Vector2 force = new Vector2(0, 3);

	private bool isTraceVisible;

	public void RotateForce(float degrees) {
		force = Quaternion.Euler(0, 0, degrees) * force;
	}

	public void ShowTrace() {
		isTraceVisible = true;
	}

	public void HideTrace() {
		isTraceVisible = false;
	}

	private void UpdateTrace() {
		if (!isTraceVisible) {
			// Hide trace
			return;
		}

		// Update trace
	}

	void Start() {
		Color color = spriteRenderer.color;
		lineRenderer.SetColors(color, color);
	}

	void Update() {
		float bearing = Mathf.Atan2(force.y, force.x);
		Vector3 angles = new Vector3(0f, 0f, bearing * Mathf.Rad2Deg - 90);
		transform.localEulerAngles = angles;

		UpdateTrace();
	}

	void FixedUpdate() {
		rigidbodyComponent.AddForce(force);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Target target = collision.gameObject.GetComponent<Target>();
		if (target != null && target.missile == this.gameObject) {
			return;
		}

    	Application.LoadLevel(Application.loadedLevel);
	}

}
