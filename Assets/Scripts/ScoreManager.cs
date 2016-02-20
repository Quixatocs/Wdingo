using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance = null; 

	private Text scoreUI;
	private float lastScoreUpdateTime;

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
		scoreUI = GameObject.FindGameObjectWithTag("ScoreBoard").transform.GetComponent<Text>();
		setScore("player", "finalScore", 0);
		Debug.Log(getScore("player", "finalScore"));

	}

	void Update () {

		//updates the score every 100th of a second
		if (Time.time - lastScoreUpdateTime >= 0.1f) {
			updateFinalScoreToUI();
			lastScoreUpdateTime = Time.time;
		}
	}

	// initialise the dictionary
	void init() {
		if (playerScores != null)
			return;
		playerScores = new Dictionary<string, Dictionary<string, int>>();
	}

	// getter, setter, changer for the score values
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

	// amount calculator for rolling score update
	private int calculateAmountToAdd() {
		GameProperties gameProperties = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameProperties>();
		int amountToAdd = gameProperties.getBaseScoreValue() * gameProperties.getScoreMultiplier();
		return amountToAdd;
	}
		
	private void updateFinalScoreToUI() {
		changeScore("player", "finalScore", calculateAmountToAdd());
		scoreUI.text = "" + getScore("player", "finalScore");
	}

}
