using UnityEngine;
using System.Collections;

public class Collidable : MonoBehaviour {
	
	public Transform player;
	
	
	void Start () {
		if (player == null) {
			player = transform;
		}
		player.GetComponent<PlayerProperties>().setCollided(false);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log ("Triggered: " + collider.name);
		player.GetComponent<PlayerProperties>().setCollided(true);
		
		//if (collider.name == "Tree1"){
		// and object called Tree1 was touched by the trigger
		
		
		//}
	}
	
	
	
}
