using UnityEngine;
using System.Collections;

public class MoveWalls : MonoBehaviour {
	public GameObject[] moveableWalls;

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.name == "Santa") {
			foreach (GameObject wall in moveableWalls)
				wall.transform.position = new Vector3(1000, 1000, 1000);
		}
	}
}
