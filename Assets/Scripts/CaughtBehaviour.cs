using UnityEngine;
using System.Collections;

public class CaughtBehaviour : MonoBehaviour {
	
	private PlayerProperties playerProperties;

	void Start () {
		playerProperties = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerProperties>();
	}

	void OnTriggerEnter2D(Collider2D collider){

		Debug.Log("Grim Collided with " + collider);
		if (collider.attachedRigidbody.transform == GameObject.FindGameObjectWithTag("Player").transform) {
			caughtPlayer();
		}
	}

	private void caughtPlayer() {
		playerProperties
		Application.LoadLevel("Replay");
	}
}
