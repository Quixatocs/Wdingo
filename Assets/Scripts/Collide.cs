using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour {

	public bool collided;


	void Start () {
		collided = false;
	}

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log ("Triggered: " + collider.name);
		collided = true;


		//if (collider.name == "Tree1"){
			// and object called Tree1 was touched by the trigger
			

		//}
	}



}
