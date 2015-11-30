using UnityEngine;
using System.Collections;

public class AnimatedCollision : MonoBehaviour {

	private Animator animator;
	public string animationName;

	void Start() {
		animator = this.gameObject.GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if(collision.gameObject.name == "Santa") {
			animator.Play(animationName, -1, 0);
		}
	}
}
