using UnityEngine;
using System.Collections;

public class SpeedUpBehaviour : MonoBehaviour {

	public Vector2 power;

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.name == "Santa") {
			collision.gameObject.GetComponent<Rigidbody2D>().AddForce(power);
		}
	}
}
