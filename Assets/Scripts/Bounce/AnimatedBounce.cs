using UnityEngine;
using System.Collections;

public class AnimatedBounce : MonoBehaviour {

	public Vector2 force;		// Сила с которой Санта отбивается от объекта
	public string animationName;
	private Animator animator;
	public GameObject scorePrebaf;
	public int scoreValue = 15;
	private ScoreBehaviour scoreScript;

	void Start() {
		scoreScript = GameObject.Find ("ScoreBoard").GetComponent<ScoreBehaviour> ();
		animator = this.GetComponent<Animator> ();
	}
	
	// Отвечает за столкновения
	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.name == "Santa") {
			collision.gameObject.GetComponent<Rigidbody2D>().AddForce(force);
			animator.Play(animationName, -1, 0);
			Instantiate(scorePrebaf, transform.position, new Quaternion());
			scoreScript.IncreaseScore(scoreValue);
		}
	}
}
