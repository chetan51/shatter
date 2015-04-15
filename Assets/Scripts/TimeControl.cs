using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour {

	public float movingTimeScale = 1.0f;
	public float stationaryTimeScale = 0.10f;
	public float fixedTimeStep = 0.02f;

	void UpdateTimeScale(float timeScale) {
		Time.timeScale = timeScale;
		Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}

	void Update () {
		UpdateTimeScale(stationaryTimeScale);

		if (Input.GetMouseButton(0)) {
			UpdateTimeScale(movingTimeScale);
		}
	}
}
