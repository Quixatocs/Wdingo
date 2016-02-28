using UnityEngine;
using System.Collections;

public class DrawBehaviour : MonoBehaviour {


	private SpriteRenderer childRenderer;
	private Transform selfPos;

	void Start () {
		// Render the gameObject and set it's sorting order
		childRenderer = GetComponentInChildren<SpriteRenderer>();
		selfPos = transform;
		childRenderer.sortingOrder = Mathf.FloorToInt(-selfPos.position.y) * 1000;
	}

	// Update is called once per frame
	void Update () {
		// if the game object is the player
		if (gameObject == GameObject.FindGameObjectWithTag("Player") 
			|| gameObject == GameObject.FindGameObjectWithTag("Nemesis")) {
			// change the sorting order dynamically as the player's position moves
			childRenderer.sortingOrder = Mathf.FloorToInt(-selfPos.position.y) * 1000;
		}
	}
}
