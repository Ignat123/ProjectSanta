using UnityEngine;
using System.Collections;

public class SticksControll : MonoBehaviour {
	
	private Rigidbody2D leftStickRigidbody, rightStickRigidbody;
	public float force = 1000;	// Сила удара

	void Start () {
		leftStickRigidbody = GameObject.Find ("LeftStick").GetComponent<Rigidbody2D> ();
		rightStickRigidbody = GameObject.Find ("RightStick").GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("left"))
			leftStickRigidbody.AddTorque(force);
		if (Input.GetKeyDown ("right")) 
			rightStickRigidbody.AddTorque(-force);
	}
}
