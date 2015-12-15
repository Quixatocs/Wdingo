using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour {

	//public variables

	public GameObject spawnA;
	public GameObject spawnB;
	public GameObject spawnC;
	public GameObject spawnD;

	//private variables

	float whichBeltSeg;
	int chosenBeltSeg;
	Vector3 spawnPos;


	// Use this for initialization
	void Start () {

		spawnA = GameObject.FindGameObjectWithTag("SpawnA");
		spawnB = GameObject.FindGameObjectWithTag("SpawnB");
		spawnC = GameObject.FindGameObjectWithTag("SpawnC");
		spawnD = GameObject.FindGameObjectWithTag("SpawnD");
		colliderSwitchAndSpawn();
	}


	void colliderSwitchAndSpawn() {
		segmentPick();
		switch (chosenBeltSeg) {
		case 1:
			setSpawnLocation(spawnA);
			break;
		case 2:
			setSpawnLocation(spawnB);
			break;
		case 3:
			setSpawnLocation(spawnC);
			break;
		case 4:
			setSpawnLocation(spawnD);
			break;
		default:
			Debug.Log("Couldn't find chosenBeltSeg for " + this.name);
			break;
		}
	}

	void setSpawnLocation(GameObject collider) {

		BoxCollider2D colz = collider.GetComponent<BoxCollider2D>();

		spawnPos = new Vector3(Random.Range((colz.bounds.center.x - colz.bounds.extents.x), (colz.bounds.center.x + colz.bounds.extents.x)),
		                       Random.Range((colz.bounds.center.y - colz.bounds.extents.y), (colz.bounds.center.y + colz.bounds.extents.y)), 0);
		this.transform.position = spawnPos;
	}

	void segmentPick() {
	whichBeltSeg = Random.value;
		if (whichBeltSeg <= 0.24) {
			chosenBeltSeg = 1;
		} else if (whichBeltSeg <= 0.49 && whichBeltSeg > 0.24) {
			chosenBeltSeg = 2;
		} else if (whichBeltSeg <= 0.74 && whichBeltSeg > 0.49) {
			chosenBeltSeg = 3;
		} else if (whichBeltSeg >= 0.74) {
			chosenBeltSeg = 4;
		}
	}
}
