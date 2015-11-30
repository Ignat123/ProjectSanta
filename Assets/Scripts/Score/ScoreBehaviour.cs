using UnityEngine;
using System.Collections;

public class ScoreBehaviour : MonoBehaviour {

	private int score = 0;
	public SpriteRenderer[] spriteRenderers;
	public Sprite[] spritesOfNumbers;

	void Start () {
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
	}
}
