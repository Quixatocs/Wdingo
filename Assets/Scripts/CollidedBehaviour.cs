using UnityEngine;
using System.Collections;

public class CollidedBehaviour : MonoBehaviour {

	private Transform player;
	private PlayerProperties playerProperties;
	private float stunnedTime;


	void Start () {
		playerProperties = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerProperties>();
	}

	//When player collides with a particular collider
	void OnTriggerEnter2D(Collider2D collider){
		SoundManager soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

		if (collider.tag == "PowerUp") {
			Debug.Log("Collided with " + collider);
			Destroy(collider.gameObject);
			soundManager.playPowerUp();
			playerProperties.changeMaxMovementVelocity(0.25f);
		}

		if (collider.tag == "SolidObject") {
			Debug.Log("Collided with " + collider);
			stunnedTime = playerProperties.getStunnedTime();
			playerProperties.setCollided(true);
			soundManager.playHitSolidObject();
			StartCoroutine(stunned(stunnedTime));
		}
	}

	IEnumerator stunned(float time) {
		Debug.Log("Stunned for " + time);
		yield return new WaitForSeconds(time);
		playerProperties.setCollided(false);
	}



}
