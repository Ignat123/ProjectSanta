using UnityEngine;
using System.Collections;

public class FlareBehaviour : MonoBehaviour {
	public GameObject flareCenterPoint;	// Центральная точка, вокруг которой двигается огонёк
	public float timeTick = 0.2f;		// Время в секундах, отвечающая за период перемещения огонька
	public float minAngle = -58.0f;  	// Минимальный угол огонька
	public float maxAngle = 2.0f;		// Максимальный угол огонька
	public float angleSpeed = -1.0f;	// Скороть изменения угла огонька
	public float power = 1000.0f;		// Сила ускорения Санты при столкновении с огнём

	public float currentAngle = 2.0f;	// Текущий угол поворота огонька
	private float lastFrameTime = 0.0f;	//Время последнего периода перемещения огонька

	void Update () {
		if (Time.time < lastFrameTime + timeTick) return;
		lastFrameTime = Time.time;
		currentAngle += angleSpeed;
		if (currentAngle < minAngle || currentAngle > maxAngle)
			angleSpeed *= -1;
		ChangeRotation ();
	}

	//Поворачивает объект по OZ согласно currentAngle
	void ChangeRotation() {
		flareCenterPoint.transform.rotation = Quaternion.Euler(flareCenterPoint.transform.rotation.x, flareCenterPoint.transform.rotation.y, currentAngle);
	}

	// Отвечает за столкновения
	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.name == "Santa") {
			PushSanta(collision.gameObject.GetComponent<Rigidbody2D>());
			collision.gameObject.GetComponent<SantasAnimation>().BurnSanta();
		}
	}

	// Толкает Санту в определённом направлении
	void PushSanta(Rigidbody2D santasRigidbody) {
		santasRigidbody.AddForce(CalculateForceVector());
	}

	// Высчитывает вектор отскока Cанты
	Vector2 CalculateForceVector(){
		float santasAngle = Mathf.PI / 180 * (currentAngle - minAngle + 1);
		return new Vector2 (Mathf.Cos (santasAngle) * power, Mathf.Sin (santasAngle) * power);
	}
}
