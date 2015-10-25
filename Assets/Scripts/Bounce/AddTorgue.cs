using UnityEngine;
using System.Collections;

public class AddTorgue : MonoBehaviour {
	public GameObject torgueObject, secondTorgueGameObject;
	public float force;

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject == torgueObject || collision.gameObject == secondTorgueGameObject) {
			gameObject.GetComponent<Rigidbody2D>().AddTorque(force);
		}
	}
}
