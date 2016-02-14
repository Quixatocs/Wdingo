using UnityEngine;
using System.Collections;

public class CollidedBehaviour : MonoBehaviour {

	private Transform player;
	private PlayerProperties playerProperties;
	private float stunnedTime;


	void Start () {
		player = transform;
		playerProperties = player.GetComponent<PlayerProperties>();
		stunnedTime = playerProperties.getStunnedTime();
	}

	//When player collides
	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log ("Triggered: " + collider.name);
		playerProperties.setCollided(true);
		StartCoroutine(stunned(stunnedTime));
	}

	IEnumerator stunned(float time) {
		Debug.Log("Stunned for " + time);
		yield return new WaitForSeconds(time);
		playerProperties.setCollided(false);
	}



}
