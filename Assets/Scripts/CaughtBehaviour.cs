using UnityEngine;
using System.Collections;

public class CaughtBehaviour : MonoBehaviour {
	
	private GameProperties gameProperties;

	void Start () {
		gameProperties = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameProperties>();
	}

	void OnTriggerEnter2D(Collider2D collider){

		Debug.Log("Grim Collided with " + collider);
		if (collider.attachedRigidbody.transform == GameObject.FindGameObjectWithTag("Player").transform) {
			caughtPlayer();
		}
	}

	private void caughtPlayer() {
		gameProperties.setPlayerCaught(true);
		GameManager.loadScene("Replay");
	}
}
