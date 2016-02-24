using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance = null;

	public AudioClip powerUp;
	public AudioClip playerCaught;
	public AudioClip startGong;
	public AudioClip hitSolidObject;
	public AudioClip nemesisTeleport;
	public AudioClip nemesisIncrease;

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

	public void playPowerUp() {
		AudioSource.PlayClipAtPoint(powerUp, Camera.main.transform.position);
	}

	public void playPlayerCaught() {
		AudioSource.PlayClipAtPoint(playerCaught, Camera.main.transform.position);
	}

	public void playStartGong() {
		AudioSource.PlayClipAtPoint(startGong, Camera.main.transform.position);
	}

	public void playHitSolidObject() {
		AudioSource.PlayClipAtPoint(hitSolidObject, Camera.main.transform.position);
	}

	public void playNemesisTeleport() {
		Transform nemesis = GameObject.FindGameObjectWithTag("Nemesis").transform;
		AudioSource.PlayClipAtPoint(nemesisTeleport, nemesis.transform.position);
	}

	public void playNemesisIncrease() {
		Transform nemesis = GameObject.FindGameObjectWithTag("Nemesis").transform;
		AudioSource.PlayClipAtPoint(nemesisIncrease, nemesis.transform.position);
	}
}
