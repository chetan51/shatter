using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Camera cam;
	public GameObject screenEdge;
	public GameObject[] toFollow;
	public float distanceBehind = 2.5f;

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

	void LateUpdate () {
		GameObject closestObject = null;
		float closestDistance = float.MaxValue;

		float distance;
		foreach (GameObject objectToFollow in toFollow) {
			distance = objectToFollow.transform.position.y + cam.orthographicSize - transform.position.y;
			if (distance < closestDistance) {
				closestDistance = distance;
				closestObject = objectToFollow;
			}
		}

		if (closestObject != null) {
			if (closestDistance > distanceBehind) {
				Vector3 position = transform.position;
				position.y = Mathf.Max(closestObject.transform.position.y + cam.orthographicSize - distanceBehind,
				                       transform.position.y);
				transform.position = position;
			}
		}
	}

}
