using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	public Rigidbody2D rigidbodyComponent;

	public float speed = 3.0f;
	public float angularSpeed = 0.1f;
	public float bearing = Mathf.PI / 2;  // TODO: Try using Rigidbody2D.rotation

	private float targetBearing;

	public void SetTargetBearing(Vector2 delta) {
		targetBearing = Mathf.Atan2(delta.y, delta.x);
	}

	void Start() {
		targetBearing = bearing;
	}

	void Update() {
		Vector3 angles = new Vector3(0f, 0f, bearing * Mathf.Rad2Deg - 90);
		transform.localEulerAngles = angles;
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
