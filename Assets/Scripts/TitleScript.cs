using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {
	

	void Update () {

		if (Input.GetMouseButtonUp(0)) {
			Debug.Log("Load Chase Level");
			Application.LoadLevel("TheChase");
		}
	
	}
}
