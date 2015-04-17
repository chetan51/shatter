using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	public Rigidbody2D rigidbodyComponent;
	public SpriteRenderer spriteRenderer;
	public LineRenderer lineRenderer;

	public float thrust = 3.0f;
	public float angularSpeed = 0.1f;
	public float bearing = Mathf.PI / 2;  // TODO: Try using Rigidbody2D.rotation

	private float targetBearing;
	private bool isTraceVisible;

	public void SetTargetBearing(Vector3 target) {
		Vector3 delta = target - transform.position;
		targetBearing = Mathf.Atan2(delta.y, delta.x);
	}

	public void ShowTrace() {
		isTraceVisible = true;
	}

	public void HideTrace() {
		isTraceVisible = false;
	}

	private void UpdateTrace() {
		if (!isTraceVisible) {
			lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
			lineRenderer.SetPosition(1, new Vector3(0, 0, 0));
			return;
		}

		float length = 5.0f;
		Vector3 start = transform.position;
		start.z += 1;
		Vector3 delta = new Vector3(length * Mathf.Cos(targetBearing),
		                            length * Mathf.Sin(targetBearing),
		                            0);
		lineRenderer.SetPosition(0, start);
		lineRenderer.SetPosition(1, start + delta);
	}

	void Start() {
		targetBearing = bearing;

		Color color = spriteRenderer.color;
		lineRenderer.SetColors(color, color);
	}

	void Update() {
		Vector3 angles = new Vector3(0f, 0f, bearing * Mathf.Rad2Deg - 90);
		transform.localEulerAngles = angles;

		UpdateTrace();
	}

	void FixedUpdate() {
		float diffBearing = Mathf.Atan2(Mathf.Sin(targetBearing - bearing),
		                                Mathf.Cos(targetBearing - bearing));
		bearing = bearing + diffBearing * angularSpeed * Time.timeScale;

		Vector2 force = new Vector2(thrust * Mathf.Cos(bearing),
	                                thrust * Mathf.Sin(bearing));
		rigidbodyComponent.AddForce(force);
	}

}
