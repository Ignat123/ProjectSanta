using UnityEngine;
using System.Collections;

public class MoveGameObject : MonoBehaviour {

	public float xSpeed = 0.0f;
	public float ySpeed = 0.0f;
	public Vector2 xPositions;
	public Vector2 yPositions;
	private Vector2 position;
	public bool fromTopToBottom = true;
	public bool fromLeftToRight = true;
	public float timeTick = 0.4f;
	private float lastFrameTime = 0.0f;

	void Start() {
		var xPosition = fromLeftToRight ? xPositions.x : xPositions.y;
		var yPosition = fromTopToBottom ? yPositions.x : yPositions.y;
		position = new Vector2 (xPosition, yPosition);
	}

	void Update () {
		if (Time.time < lastFrameTime + timeTick) return;
		if (xPositions.x != xPositions.y)
			MoveX ();
		if (yPositions.x != yPositions.y)
			MoveY ();
	}

	void MoveX() {
		if (position.x > xPositions.y || position.x < xPositions.x)
			xSpeed *= -1;
		position.x += xSpeed;
		gameObject.transform.position = new Vector3 (transform.position.x + xSpeed, transform.position.y, transform.position.z);
	}

	void MoveY() {
		if (position.y > yPositions.y || position.y < yPositions.x)
			ySpeed *= -1;
		position.y += ySpeed;
		transform.position = new Vector3 (transform.position.x, transform.position.y + ySpeed, transform.position.z);
	}
}
