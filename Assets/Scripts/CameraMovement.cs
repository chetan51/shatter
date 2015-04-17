using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Camera cam;
	public GameObject screenEdge;

	void Start() {
		float height = cam.orthographicSize;
		float width = height * cam.aspect;

		EdgeCollider2D colliderComponent = screenEdge.GetComponent<EdgeCollider2D>();
		colliderComponent.points = new Vector2[] {new Vector2(-width, -height),
												  new Vector2(-width, height),
												  new Vector2(width, height),
												  new Vector2(width, -height),
												  new Vector2(-width, -height)};
	}

}
