using UnityEngine;
using System.Collections;

public class ScoreFlyer : MonoBehaviour {

	public float speed = 0.5f;
	public float maxHeight = 10;
	private float lastFrameTime = 0.0f;	
	
	void Update () {
		if (Time.time < lastFrameTime + 0.04) return;
		lastFrameTime = Time.time;
		maxHeight--;
		this.transform.position = new Vector3 (this.transform.position.x,
      		this.transform.position.y + speed, this.transform.position.z);
		if (maxHeight < 0)
			Destroy (this.gameObject);
	}
}
