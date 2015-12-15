using UnityEngine;
using System.Collections;

public class StaticOrderInLayer : MonoBehaviour {
	
	private SpriteRenderer childRenderer;
	private Transform selfPos;
	
	void Awake () {
		
		childRenderer = GetComponentInChildren<SpriteRenderer>();
		selfPos = transform;
		childRenderer.sortingOrder = Mathf.FloorToInt(-selfPos.position.y);
	}
	

}
