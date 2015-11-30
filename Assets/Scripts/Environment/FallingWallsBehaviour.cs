using UnityEngine;
using System.Collections;

public class FallingWallsBehaviour : MonoBehaviour {
	public GameObject fallingWall;
	public float fallingSpeed = 3.0f;
	public Vector2 wallAngles;
	public float frameTick = 0.04f;
	private float lastFrameTime = 0.0f;
	private float angle;
	public bool isWallFall = false;
	private bool isWallStayStrict = true;
	private float wallStayStricktTime = 0.0f;
	public float maxStayStrictTime = 5.0f;

	void Start() {
		angle = 0;
	}

	void Update () {
		if (isWallStayStrict) return;
		if (Time.time < lastFrameTime + frameTick) return;
		lastFrameTime = Time.time;
		if (maxStayStrictTime < wallStayStricktTime) {
			ReturnWall ();
			return;
		}
		MoveWall ();
	}

	void ReturnWall() {
		if (isWallFall && angle < 0 + fallingSpeed) {
			angle += fallingSpeed;
		} else if (!isWallFall && angle > 0 - fallingSpeed)
			angle -= fallingSpeed;
		else {
			angle = 0;
			isWallStayStrict = true;
		}
		fallingWall.transform.rotation = Quaternion.Euler (fallingWall.transform.rotation.x, fallingWall.transform.rotation.y, angle);
	}

	void MoveWall(){
		if (isWallFall && angle > wallAngles.x) {
			angle -= fallingSpeed;
		} else if (!isWallFall && angle < wallAngles.y)
			angle += fallingSpeed;
		else
			wallStayStricktTime += frameTick;
		fallingWall.transform.rotation = Quaternion.Euler (fallingWall.transform.rotation.x, fallingWall.transform.rotation.y, angle);
	}

	public void PushWall() {
		wallStayStricktTime = 0.0f;
		isWallStayStrict = false;
		isWallFall = !isWallFall;
	}
}
