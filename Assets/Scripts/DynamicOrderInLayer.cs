using UnityEngine;
using System.Collections;

public class DynamicOrderInLayer : MonoBehaviour {


	private SpriteRenderer childRenderer;
	private Transform selfPos;
	
	void Awake () {
		
		childRenderer = GetComponentInChildren<SpriteRenderer>();
		selfPos = transform;

	}
	
	// Update is called once per frame
	void Update () {
		childRenderer.sortingOrder = Mathf.FloorToInt(-selfPos.position.y);
	}
}
