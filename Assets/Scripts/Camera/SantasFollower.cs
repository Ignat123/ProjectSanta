using UnityEngine;
using System.Collections;

public class SantasFollower : MonoBehaviour {

	public float minPosition = -6.63f;
	private GameObject santa;

	void Start() {
		santa = GameObject.Find ("Santa");
	}

	void Update () {
		if (santa.transform.position.y > minPosition)
			transform.position = new Vector3 (transform.position.x, santa.transform.position.y, transform.position.z);
	}
}
