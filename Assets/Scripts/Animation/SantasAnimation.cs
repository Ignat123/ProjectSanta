using UnityEngine;
using System.Collections;

public class SantasAnimation : MonoBehaviour {

	bool isFacingRight = false;
	Rigidbody2D santasRigidbody;
	Animator animator;

	void Start() {
		santasRigidbody = gameObject.GetComponent<Rigidbody2D> ();
		animator = gameObject.GetComponent<Animator> ();
	}

	void Update () {
		FaceSanta(santasRigidbody.velocity.x);
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("SantaOnFire"))
			PitOutSanta();
	}

	void PitOutSanta() {
		if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 ) {
			animator.Play ("SantaIdle");
		}
	}

	void FaceSanta(float velocity)
	{
		if(velocity > 10 && !isFacingRight)
			Flip();
		else if (velocity < -10 && isFacingRight)
			Flip();
	}

	public void BurnSanta() {
		animator.Play ("SantaOnFire");
	}

	void Flip()
	{
		isFacingRight = !isFacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
