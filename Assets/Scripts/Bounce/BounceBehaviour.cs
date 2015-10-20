using UnityEngine;
using System.Collections;

public class BounceBehaviour : MonoBehaviour {

	public Vector2 force;		// Сила с которой Санта отбивается от объекта

	// Отвечает за столкновения
	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.name == "Santa") {
			collision.gameObject.GetComponent<Rigidbody2D>().AddForce(force);
		}
	}
}
