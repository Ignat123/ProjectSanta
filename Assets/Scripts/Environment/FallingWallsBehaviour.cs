using UnityEngine;
using System.Collections;

public class FallingWallsBehaviour : MonoBehaviour {
	public GameObject fallingWall;
	public float fallingSpeed = 3.0f;
	public Vector2 wallAngles;
	public Sprite firstSprite;
	public Sprite secondSprite;
	public float frameTick = 0.04f;
	private float lastFrameTime = 0.0f;
	private float angle;
	public bool isWallFall = false;
	private bool isWallStayStrict = true;

	void Start() {
		angle = wallAngles.y;
	}

	void Update () {
		if (isWallStayStrict) return;
		if (Time.time < lastFrameTime + frameTick) return;
		lastFrameTime = Time.time;
		moveWall ();
	}

	void moveWall(){
		if (isWallFall && angle > wallAngles.x) {
			angle -= fallingSpeed;
		} else if (!isWallFall && angle < wallAngles.y)
			angle += fallingSpeed;
		fallingWall.transform.rotation = Quaternion.Euler (fallingWall.transform.rotation.x, fallingWall.transform.rotation.y, angle);
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.name == "Santa") {
			isWallStayStrict = false;
			Sprite currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
			gameObject.GetComponent<SpriteRenderer>().sprite = currentSprite == firstSprite ? secondSprite : firstSprite;
			isWallFall = !isWallFall;
		}
	}
}
