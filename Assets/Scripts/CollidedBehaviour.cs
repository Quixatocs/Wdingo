using UnityEngine;
using System.Collections;

public class CollidedBehaviour : MonoBehaviour {

	private Transform player;
	private PlayerProperties playerProperties;
	private float stunnedTime;


	void Start () {
		playerProperties = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerProperties>();

	}

	//When player collides
	void OnTriggerEnter2D(Collider2D collider){

		if (collider.tag == "PowerUp") {
			Debug.Log("Collided with " + collider);
			playerProperties.changeMaxMovementVelocity(0.25f);
		}

		if (collider.tag == "SolidObject") {
			Debug.Log("Collided with " + collider);
			stunnedTime = playerProperties.getStunnedTime();
			playerProperties.setCollided(true);
			StartCoroutine(stunned(stunnedTime));
		}
	}

	IEnumerator stunned(float time) {
		Debug.Log("Stunned for " + time);
		yield return new WaitForSeconds(time);
		playerProperties.setCollided(false);
	}



}
