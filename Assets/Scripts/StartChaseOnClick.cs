using UnityEngine;
using System.Collections;

public class StartChaseOnClick : MonoBehaviour {

	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			GameManager.loadScene("TheChase");
		}
	}
}
