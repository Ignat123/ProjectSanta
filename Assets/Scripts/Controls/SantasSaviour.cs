using UnityEngine;
using System.Collections;

public class SantasSaviour : MonoBehaviour {
	private Vector3 gameObjectLastPosition;
	private int stuckCount = 0;
	public float timeTick = 0.04f;
	private float lastFrameTime = 0.0f;
	public Vector2 limitPositions = new Vector2(0.0f, 0.0f);
	
	void Start() {
		gameObjectLastPosition = gameObject.transform.position;
	}
	
	void Update () {
		if (Time.time < lastFrameTime + timeTick) return;
		lastFrameTime = Time.time;
		if (transform.position.y < -20) {
			gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			gameObject.transform.position = new Vector3 (-8.88f, 9.2f, 0f);
		}
		UnStuck ();
	}
	
	void UnStuck(){
		if (gameObjectLastPosition != gameObject.transform.position)
			gameObjectLastPosition = gameObject.transform.position;
		else {
			stuckCount++;
			if (stuckCount >= 2) {
				Debug.Log("Unstuck santa");
				stuckCount = 0;
				float xSpeed = transform.position.x > limitPositions.x ? -0.5f : 0.5f;
				float ySpeed = transform.position.y > limitPositions.y ? -0.5f : 0.5f;
				transform.position = new Vector3(transform.position.x + xSpeed, transform.position.y + ySpeed, 0);
			}
		}
	}
}
