using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float timeTick = 0.2f;		// Время одного кадра
	public float rotationAngle = 2.0f;	// Скорость вращения элемента
	private float lastFrameTime = 0.0f;	//Время последнего кадра	

	void Update () {
		if (Time.time < lastFrameTime + timeTick) return;
		lastFrameTime = Time.time;
		gameObject.transform.Rotate (0, 0, rotationAngle);
	}
}
