using UnityEngine;
using System.Collections;

public class MissileControl : MonoBehaviour {

	public Collider2D colliderComponent;
	public Missile missile;

	public float rotationSensitivity = 2.0f;

	private bool isActive;
	private Vector2 lastInputPosition;

	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			isActive = false;
			missile.HideTrace();
		}

		if (Input.GetMouseButton(0)) {
			Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 inputPosition = new Vector2(worldPoint.x, worldPoint.y);

			if (Input.GetMouseButtonDown(0)) {
				if (colliderComponent == Physics2D.OverlapPoint(inputPosition)) {
					lastInputPosition = inputPosition;
					isActive = true;
					missile.ShowTrace();
				}
			}

			if (isActive) {
				float degrees = lastInputPosition.x - inputPosition.x;
				if (degrees != 0) {
					missile.RotateForce(degrees * rotationSensitivity);
				}
			}

			lastInputPosition = inputPosition;
		}
	}

}
