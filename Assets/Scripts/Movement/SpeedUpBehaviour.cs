using UnityEngine;
using System.Collections;

public class SpeedUpBehaviour : MonoBehaviour {

	public Vector2 power;

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.name == "Santa") {
			if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y / power.y > 0)
				collision.gameObject.GetComponent<Rigidbody2D>().AddForce(power);
		}
	}
}
