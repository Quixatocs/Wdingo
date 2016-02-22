using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null; 

	public GameObject player;
	public GameObject nemesis;
	public GameObject tree1;


	float dice;

	public static int numberTrees;


	//Max number of Objects
	public int maxTrees = 100;

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
		
	public static void loadScene(string sceneName) {
		Debug.Log("Loading " + sceneName);
		switch (sceneName) {
		case "Title":
			SceneManager.LoadScene(0);
			break;
		case "TheChase":
			SceneManager.LoadScene(1);
			break;
		case "Replay":
			SceneManager.LoadScene(2);
			break;
		default :
			Debug.Log(sceneName + " is not a valid scene name");
			break;
		}
	}

	void OnLevelWasLoaded(int sceneNumber) {
		ScoreManager scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").transform.GetComponent<ScoreManager>();
		switch (sceneNumber) {
		case 0:
			break;
		case 1:
			scoreManager.setScore("player", "finalScore", 0);
			setupChaseScene();
			runChaseScene();
			break;
		case 2:
			scoreManager.updateFinalScoreToUI();
			break;
		default:
			break;
		}

	}

	private void setupChaseScene() {
		GameProperties gameProperties = GameObject.FindGameObjectWithTag("GameManager").transform.GetComponent<GameProperties>();
		gameProperties.setPlayerCaught(false);
	}

	private void runChaseScene() {
		Instantiate(player);
		//StartCoroutine(spawn());
		if (player != null) {
			StartCoroutine(spawnNemesis());
		}
	}

	IEnumerator spawn() {
		while (numberTrees < maxTrees) {
			spawnTrees();
			numberTrees++;
			yield return null;
		}
	}

	// Spawns nemesis after a few seconds
	IEnumerator spawnNemesis() {
		yield return new WaitForSeconds(5.0f);
		Instantiate(nemesis);
	}

	void spawnTrees(){

		// add a tree loading message

		
			dice = Random.Range (0,500);
			if (dice <= 99) {
				Instantiate(tree1);
			} else if (dice <= 199 && dice > 99) {
				Instantiate(tree1);
			} else if (dice <= 299 && dice > 199) {
				Instantiate(tree1);
			} else if (dice <= 399 && dice > 299) {
				Instantiate(tree1);
			} else if (dice <= 499 && dice > 399) {
				Instantiate(tree1);
			}

	}
}
