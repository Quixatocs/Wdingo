using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour {

	//public variables



	//private variables


	// Use this for initialization
	void Start () {

		transform.position = Random.insideUnitCircle * 200;

	}


}
