using UnityEngine;
using System.Collections;

public class SticksControll : MonoBehaviour {

	public Vector2 force = new Vector2 (80, 60);	// Сила удара
	public Vector2 leftStickAngles = new Vector2(-44, 84);	// Углы для левого стика
	public Vector2 rightStickAngles = new Vector2(-84, 44);
	public GameObject leftStick, rightStick;
	public bool isLeftStickPressed, isRightStickPressed;	//Отвечает за проверку, нажаты ли клавиши
	public float timeTick = 0.02f;		// Время в секундах, отвечающая за выполнения операции
	private float lastFrameTime = 0.0f;	//Время последнего выполнения операции
	public float leftStickAngle, rightStickAngle;	//Углы поворота стиков
	public float stickSpeed = 5.0f;
	public GameObject santa;
	public GameObject leftStickSolid, rightStickSolid;
	private bool isCollisionIgnored = false;
	private float lastCollisionIgnoreTime = 0f;
	private bool leftStickGoinDown = false;
	private bool rightStickGoinDown = false;

	
	void Start() {
		leftStickAngle = leftStickAngles.x;
		rightStickAngle = rightStickAngles.y;
	}

	void Update () {
		if (Time.time < lastFrameTime + timeTick) return;
		lastFrameTime = Time.time;
		isLeftStickPressed = false; isRightStickPressed = false;
		if (Input.GetKey ("left"))
			isLeftStickPressed = true;
		if (Input.GetKey ("right"))
			isRightStickPressed = true;
		if (isCollisionIgnored)
			DisableIgnoreCollision ();
		MoveSticks ();
	}

	void DisableIgnoreCollision(){ 
		if (lastCollisionIgnoreTime + 0.5f < Time.time) { 
			isCollisionIgnored = false;
			Physics2D.IgnoreCollision(santa.GetComponent<Collider2D>(), leftStickSolid.GetComponent<Collider2D>(), false);
			Physics2D.IgnoreCollision(santa.GetComponent<Collider2D>(), rightStickSolid.GetComponent<Collider2D>(), false);
		}
	}

	void MoveSticks() {
		leftStickGoinDown = false;
		rightStickGoinDown = false;
		if (isLeftStickPressed && leftStickAngle < leftStickAngles.y)
			leftStickAngle += stickSpeed;
		else if (!isLeftStickPressed && leftStickAngle > leftStickAngles.x) {
			leftStickGoinDown = true;
			leftStickAngle -= stickSpeed;
		}

		if (isRightStickPressed && rightStickAngle > rightStickAngles.x)
			rightStickAngle -= stickSpeed;
		else if (!isRightStickPressed && rightStickAngle < rightStickAngles.y) {
			rightStickGoinDown = true;
			rightStickAngle += stickSpeed;
		}

		if (leftStickAngle < leftStickAngles.x)
			leftStickAngle = leftStickAngles.x;
		if (leftStickAngle > leftStickAngles.y)
			leftStickAngle = leftStickAngles.y;

		if (rightStickAngle < rightStickAngles.x)
			rightStickAngle = rightStickAngles.x;
		if (rightStickAngle > rightStickAngles.y)
			rightStickAngle = rightStickAngles.y;

		leftStick.transform.rotation = Quaternion.Euler (leftStick.transform.rotation.x, leftStick.transform.rotation.y, leftStickAngle);
		rightStick.transform.rotation = Quaternion.Euler (leftStick.transform.rotation.x, leftStick.transform.rotation.y, rightStickAngle);
	}

	public void Hit(Vector2 power, GameObject stick, GameObject solid) {
		if (stick == leftStick) 
			if (leftStickAngle >= leftStickAngles.y || leftStickAngle <= leftStickAngles.x || leftStickGoinDown)
				return;
		if (stick == rightStick)
			if (rightStickAngle >= rightStickAngles.y || rightStickAngle <= rightStickAngles.x || rightStickGoinDown)
				return;
		power = CalculatePower(stick, santa);
		Physics2D.IgnoreCollision(santa.GetComponent<Collider2D>(), solid.GetComponent<Collider2D>());
		isCollisionIgnored = true; 
		lastCollisionIgnoreTime = Time.time;
		santa.GetComponent<Rigidbody2D> ().AddForce (power);
	}

	public Vector2 CalculatePower(GameObject stick, GameObject santa) {
		var xSpeed = (Mathf.Abs(santa.transform.position.x) + Mathf.Abs(stick.transform.position.x)) * force.x;
		if (santa.transform.position.x < stick.transform.position.x)
		    xSpeed *= -1;
		return new Vector2 (xSpeed, (Mathf.Abs(santa.transform.position.y) + Mathf.Abs(stick.transform.position.y)) * force.y);
	}
}
