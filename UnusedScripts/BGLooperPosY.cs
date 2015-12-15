using UnityEngine;
using System.Collections;

public class BGLooperPosY : MonoBehaviour {

	int numBGPanels = 6;
	
	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("Triggered: " + collider.name);
		
		float heightOfBGObject = ((BoxCollider2D)collider).size.y;
		Vector3 pos = collider.transform.position;
		pos.y -= heightOfBGObject * (numBGPanels - 1) + heightOfBGObject/2;
		collider.transform.position = pos;
	}
}
