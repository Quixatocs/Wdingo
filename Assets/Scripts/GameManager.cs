using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null; 

	public GameObject player;
	public GameObject nemesis;
	public GameObject speedPowerUp;
	public GameObject tree1;

	private int maxNumberOfPowerUps = 100;

	float dice;

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

	void Awake() {
		singletonThis();
	}

	void Update() {
		if (Input.GetKey("escape")) {
			Debug.Log("Quit Attempted");
			Application.Quit();
		}
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
		SoundManager soundManager = GameObject.FindGameObjectWithTag("SoundManager").transform.GetComponent<SoundManager>();
		switch (sceneNumber) {
		case 0:
			break;
		case 1:
			scoreManager.setScore("player", "finalScore", 0);
			setupChaseScene();
			soundManager.playStartGong();
			runChaseScene();
			break;
		case 2:
			soundManager.playPlayerCaught();
			scoreManager.updateFinalScoreToUI();
			break;
		default:
			break;
		}

	}

	private void resetAllEntityPropertiesToDefaults() {
		RandomSeedManager randomSeedManager = GameObject.FindGameObjectWithTag("RandomSeedManager").transform.GetComponent<RandomSeedManager>();
		randomSeedManager.resetToDefaults();
		GameProperties gameProperties = GameObject.FindGameObjectWithTag("GameManager").transform.GetComponent<GameProperties>();
		gameProperties.resetToDefaults();
		PlayerProperties playerProperties = GameObject.FindGameObjectWithTag("GameManager").transform.GetComponent<PlayerProperties>();
		playerProperties.resetToDefaults();
		NemesisProperties nemesisProperties = GameObject.FindGameObjectWithTag("GameManager").transform.GetComponent<NemesisProperties>();
		nemesisProperties.resetToDefaults();
	}

	private void setupChaseScene() {
		resetAllEntityPropertiesToDefaults();
	}

	private void runChaseScene() {
		StartCoroutine(spawn());
		Instantiate(player);
		Camera.main.GetComponent<CameraFollowBehaviour>().setCameraToTargetPlayer();
		if (player != null) {
			StartCoroutine(spawnNemesis());
		}
	}

	IEnumerator spawn() {
		for (int i = 0; i < maxTrees; i++) {
			spawnTrees();
		}
		for (int i = 0; i < maxNumberOfPowerUps; i++) {
			spawnPowerUps();
		}
		yield return null;
	}

	// Spawns nemesis after a few seconds
	IEnumerator spawnNemesis() {
		yield return new WaitForSeconds(5.0f);
		Instantiate(nemesis);
	}

	private void spawnTrees(){

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

	private void spawnPowerUps() {
		Instantiate(speedPowerUp);
	}

}
