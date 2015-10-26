using UnityEngine;
using System.Collections;

public class SantasSaviour : MonoBehaviour {

	void Update () {
		if (transform.position.y < -20) {
			gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			gameObject.transform.position = new Vector3 (-8.88f, 9.2f, 0f);
		}
	}
}
