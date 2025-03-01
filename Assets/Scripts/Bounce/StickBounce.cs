﻿using UnityEngine;
using System.Collections;

public class StickBounce : MonoBehaviour {

	public float power = 5000;
	public GameObject santa;
	public GameObject stickController;
	public GameObject stick;

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject == santa) {
			stickController.GetComponent<SticksControll>().Hit(new Vector2(power, power), stick, gameObject);
			SetPressure(true);
		}
	}

	void OnCollisionStay2D(Collision2D collision) {
		if(collision.gameObject == santa) {
			stickController.GetComponent<SticksControll>().Hit(new Vector2(power, power), stick, gameObject);
			SetPressure(true);
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		if(collision.gameObject == santa) 
			SetPressure(false);
	}

	void SetPressure(bool value) {
		santa.GetComponent<SantasSaviour> ().SetPressure (value);
	}
}
