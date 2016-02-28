using UnityEngine;
using System.Collections;

public class GameProperties : MonoBehaviour {

	// Bool properties
	private bool playerCaught = false;

	// Game properties
	private int baseScoreValue = 1;
	private int scoreMultiplier = 1;

	public void resetToDefaults() {
		setPlayerCaught(false);
		setBaseScoreValue(1);
		setScoreMultiplier(1);
	}

	//Getter and Setter for caught bool 
	public void setPlayerCaught(bool newCaughtState) {
		this.playerCaught = newCaughtState;
	}

	public bool isPlayerCaught() {
		return this.playerCaught;
	}

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
