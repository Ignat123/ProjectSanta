using UnityEngine;
using System.Collections;

public class LightBehaviour : MonoBehaviour {
	public Sprite firstSprite;
	public Sprite secondSprite;
	public GameObject spriteOwner;

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.name == "Santa") {
			Sprite currentSprite = spriteOwner.GetComponent<SpriteRenderer>().sprite;
			spriteOwner.GetComponent<SpriteRenderer>().sprite = currentSprite == firstSprite ? secondSprite : firstSprite;
		}
	}
}
