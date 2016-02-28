using UnityEngine;
using System.Collections;
//using UnityEditor;

public class RandomSeedManager : MonoBehaviour {

	public static RandomSeedManager instance = null; 

	private int randomSeed;
	private int intToEdit = 1337;

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
		setRandomSeed(intToEdit);
	}

	public void resetToDefaults() {
		Random.seed = randomSeed;
	}

	public void setRandomSeed(int seedInputValue) {
		Random.seed = seedInputValue;
	}
		
	void OnGUI() {
		randomSeed = intToEdit; //EditorGUI.IntField(new Rect(10, 10, 60, 20), intToEdit);
	}

}
