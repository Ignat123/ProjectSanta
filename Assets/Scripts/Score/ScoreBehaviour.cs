using UnityEngine;
using System.Collections;

public class ScoreBehaviour : MonoBehaviour {

	private int score = 0;
	public SpriteRenderer[] spriteRenderers;
	public Sprite[] spritesOfNumbers;
	private float startPositionX;

	void Start () {
		startPositionX = transform.position.x;
		setScore ();
	}

	public void IncreaseScore(int value) {
		score += value;
		setScore ();
	}

	void setScore() {
		int tempScore = score, position = 0, currentValue = 0;
		while (tempScore != 0) {
			currentValue = tempScore % 10;
			tempScore /= 10;
			spriteRenderers[position].sprite = spritesOfNumbers[currentValue];
			position++;
		}
		float padding  = score.ToString().Length - 1.0f;
		transform.position = new Vector3(
			startPositionX - 1.86f + 0.25f * padding, transform.position.y, transform.position.z);
	}
}
