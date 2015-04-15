using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public Collider2D colliderComponent;
	public Missile missile;

	public float movementThreshold = 0.5f;

	private bool isActive;
	private Vector2 initialInputPosition;

	void Update () {
		if (Input.GetMouseButton(0)) {
			Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 inputPosition = new Vector2(worldPoint.x, worldPoint.y);

			if (Input.GetMouseButtonDown(0)) {
				isActive = false;

				if (colliderComponent == Physics2D.OverlapPoint(inputPosition)) {
					initialInputPosition = inputPosition;
					isActive = true;
				}
			}

			if (isActive) {
				Vector2 delta = inputPosition - initialInputPosition;

				if (delta.magnitude > movementThreshold) {
					missile.SetTargetBearing(delta);
				}
			}
		}
	}

}
