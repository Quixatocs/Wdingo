using UnityEngine;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance = null; 

	Dictionary<string, Dictionary<string, int>> playerScores;

	void singletonThis() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}

	void Awake () {
		singletonThis();
	}

	void Start () {
		setScore("player", "mainscore", 0);
		Debug.Log(getScore("player", "mainscore"));
	}

	void init() {
		if (playerScores != null)
			return;
		playerScores = new Dictionary<string, Dictionary<string, int>>();
	}

	public int getScore(string username, string scoreType) {
		init();

		if (playerScores.ContainsKey(username) == false) {
			return 0;
		}

		if (playerScores[username].ContainsKey(scoreType) == false) {
			return 0;
		}

		return playerScores[username][scoreType];
	}

	public void setScore(string username, string scoreType, int value) {
		init();

		if (playerScores.ContainsKey(username) == false) {
			playerScores[username] = new Dictionary<string, int>();
		}

		playerScores[username][scoreType] = value;
	}

	public void changeScore(string username, string scoreType, int amount) {
		init();
		int currentScore = getScore(username, scoreType);
		setScore(username, scoreType, currentScore + amount);
	}

}
