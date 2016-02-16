using UnityEngine;
using System.Collections;

public class GameProperties : MonoBehaviour {

	// Game properties
	private int baseScoreValue = 1;
	private int scoreMultiplier = 1;

	public int getBaseScoreValue() {
		return baseScoreValue;
	}

	public void setBaseScoreValue(int baseScoreValue) {
		this.baseScoreValue = baseScoreValue;
	}

	public int getScoreMultiplier() {
		return scoreMultiplier;
	}

	public void setScoreMultiplier(int scoreMultiplier) {
		this.scoreMultiplier = scoreMultiplier;
	}



}
