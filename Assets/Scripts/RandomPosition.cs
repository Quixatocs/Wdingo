using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour {

	void Start () {
		transform.position = Random.insideUnitCircle * 200;
	}


}
