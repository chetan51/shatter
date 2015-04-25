using UnityEngine;
using System.Collections;

public class ProjectileControl : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public LineRenderer lineRenderer;
	public Collider2D colliderComponent;
	public Projectile projectile;

	private bool isActive;
	private bool isControllable = true;
	private Vector2 startInputPosition;
	private Vector2 endInputPosition;

	private void UpdateTrace() {
		if (isActive) {
			lineRenderer.SetVertexCount(2);
			lineRenderer.SetPosition(0, startInputPosition);
			lineRenderer.SetPosition(1, endInputPosition);
		}
		else {
			lineRenderer.SetVertexCount(0);
		}
	}

	void Start() {
		Color startColor = spriteRenderer.color;
		Color endColor = startColor;
		endColor.a = 0f;
		lineRenderer.SetColors(startColor, endColor);
	}

	void Update () {
		if (isActive && Input.GetMouseButtonUp(0)) {
			projectile.AddForce(endInputPosition - startInputPosition);
			isActive = false;
			isControllable = false;
		}

		if (isControllable && Input.GetMouseButton(0)) {
			Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 inputPosition = new Vector2(worldPoint.x, worldPoint.y);

			if (Input.GetMouseButtonDown(0)) {
				if (colliderComponent == Physics2D.OverlapPoint(inputPosition)) {
					startInputPosition = inputPosition;
					isActive = true;
				}
			}

			if (isActive) {
				endInputPosition = inputPosition;
			}
		}

		UpdateTrace();
	}

}
