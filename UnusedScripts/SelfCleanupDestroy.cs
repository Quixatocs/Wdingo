using UnityEngine;
using System.Collections;

public class SelfCleanupDestroy : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Destroy(this.gameObject);
		GameManager.numberSpawned--;
	}
}
