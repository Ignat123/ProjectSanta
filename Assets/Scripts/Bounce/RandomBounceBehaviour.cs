using UnityEngine;
using System.Collections;

public class RandomBounceBehaviour : MonoBehaviour {

	public Vector2 force;		// Сила с которой Санта отбивается от объекта
	public Vector2 offset;		// Смещение относительно силы удара
	
	// Отвечает за столкновения
	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.name == "Santa") {
			float xOffset = (10 - Random.Range (0, offset.x)) / 10;
			float yOffset = (10 - Random.Range (0, offset.y)) / 10;
			collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(force.x * xOffset, force.y * yOffset));
		}
	}
}
