using UnityEngine;
using System.Collections;

public class IgnoroCollision : MonoBehaviour {

	public GameObject[] collisionGameObjects;
	
	void Start () {
		foreach(var collisionGameObject in collisionGameObjects)
			Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collisionGameObject.GetComponent<Collider2D>());
	}
}
