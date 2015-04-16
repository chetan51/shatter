using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	public Rigidbody2D rigidbodyComponent;
	public SpriteRenderer spriteRenderer;

	public float speed = 3.0f;
	public float angularSpeed = 0.1f;
	public float bearing = Mathf.PI / 2;  // TODO: Try using Rigidbody2D.rotation
	public int numTracers = 10;

	private float targetBearing;
	private GameObject[] tracers;

	public void SetTargetBearing(Vector2 delta) {
		targetBearing = Mathf.Atan2(delta.y, delta.x);
	}

	public void ShowTrace() {
		for (int i = 0; i < numTracers; i++) {
			tracers[i].SetActive(true);
		}

		UpdateTrace();
	}

	public void HideTrace() {
		for (int i = 0; i < numTracers; i++) {
			tracers[i].SetActive(false);
		}
	}

	private void UpdateTrace() {
		for (int i = 0; i < numTracers; i++) {
			Vector3 position = transform.position;
			position.y += (i + 1) * .5f;
			tracers[i].transform.position = position;
		}
	}

	void Start() {
		targetBearing = bearing;
		tracers = new GameObject[numTracers];

		SpriteRenderer tracerSpriteRenderer;
		Color color;

		for (int i = 0; i < numTracers; i++) {
			tracers[i] = Instantiate(Resources.Load("MissileTracer") as GameObject);
			tracers[i].transform.SetParent(this.transform, false);

			tracerSpriteRenderer = tracers[i].GetComponent<SpriteRenderer>();
			color = spriteRenderer.color;
			color.a = Mathf.Lerp(1, 0, (float)i / numTracers);
			tracerSpriteRenderer.color = color;

			tracers[i].SetActive(false);
		}
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

		Vector2 movement = new Vector2(speed * Mathf.Cos(bearing),
		                               speed * Mathf.Sin(bearing));
		rigidbodyComponent.velocity = movement;
	}

}
