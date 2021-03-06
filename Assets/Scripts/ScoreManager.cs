﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance = null; 

	private GameProperties gameProperties;
	private float lastScoreUpdateTime;

	private Text finalScoreUI;

	Dictionary<string, Dictionary<string, int>> playerScores;
	 

	void singletonThis() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	void Awake () {
		singletonThis();
	}

	void Start () {
		gameProperties = GameObject.FindGameObjectWithTag("GameManager").transform.GetComponent<GameProperties>();
	}

	void Update () {

		//updates the score every 100th of a second
		if (Time.time - lastScoreUpdateTime >= 0.1f && !gameProperties.isPlayerCaught() && SceneManager.GetActiveScene().buildIndex == 1) {
			updateScoreToUI();
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

	private void updateScoreToUI() {
		changeScore("player", "finalScore", calculateAmountToAdd());
		if (finalScoreUI == null) {
			finalScoreUI = GameObject.FindGameObjectWithTag("FinalScore").transform.GetComponent<Text>();
		}
		finalScoreUI.text = "" + getScore("player", "finalScore");
	}

	public void updateFinalScoreToUI() {
		if (finalScoreUI == null) {
			finalScoreUI = GameObject.FindGameObjectWithTag("FinalScore").transform.GetComponent<Text>();
		}
		finalScoreUI.text = "" + getScore("player", "finalScore");
	}

}
