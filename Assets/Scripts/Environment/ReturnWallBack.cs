using UnityEngine;
using System.Collections;

public class ReturnWallBack : MonoBehaviour {

	public GameObject[] moveableWalls;
	public Vector3[] wallPositions;

	void Start() {
		wallPositions = new Vector3[moveableWalls.Length];
		for (int i = 0; i < moveableWalls.Length; i++)
			wallPositions[i] = moveableWalls[i].transform.position;
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.name == "Santa") {
			for (int i = 0; i < moveableWalls.Length; i++)
				moveableWalls[i].transform.position = wallPositions[i];
		}
	}
}
