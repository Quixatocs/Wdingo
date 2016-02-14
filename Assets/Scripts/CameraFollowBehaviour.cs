using UnityEngine;
using System.Collections;

public class CameraFollowBehaviour : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform player;

	//
	void Start () {
		GameObject playerGO = GameObject.FindGameObjectWithTag("Player");

		if(playerGO == null) {
			Debug.LogError ("Couldn't find an object with tag 'Player'!");
			return;
		}
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}


	// Update is called once per frame
	void Update () 
	{

		Vector3 point = GetComponent<Camera>().WorldToViewportPoint(player.position);
		Vector3 delta = player.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
		Vector3 destination = transform.position + delta;
		transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

	}
}