using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public Vector2 speed = new Vector2(0, 2);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3 (speed.x, speed.y, 0);
		movement *= Time.deltaTime;
		transform.Translate(movement);
	}
}
