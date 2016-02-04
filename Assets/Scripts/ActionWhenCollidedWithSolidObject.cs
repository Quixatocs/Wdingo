using UnityEngine;
using System.Collections;

public class ActionWhenCollidedWithSolidObject : MonoBehaviour {
	
	public Transform player;
	
	
	void Start () {
		if (player == null) {
			player = transform;
		}
		player.GetComponent<PlayerProperties>().setCollided(false);
	}

	//When player collides
	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log ("Triggered: " + collider.name);
		player.GetComponent<PlayerProperties>().setCollided(true);
		removeFromSolidSpace(collider);
	}

	public void removeFromSolidSpace(Collider2D collider) {
		Debug.Log("Moving " + player + " out of: " + collider.name);

	}
	
	
	
}
