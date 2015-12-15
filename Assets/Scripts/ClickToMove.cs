using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	public Camera cam;
	public Transform player;
	public float distanceFromCamera;
	public Rigidbody2D r;



	void Start () {
		cam = Camera.main;
		player = transform;
		distanceFromCamera = Vector3.Distance (player.position, cam.transform.position);
		r = player.GetComponent<Rigidbody2D>();

	}
	
	void Update () {


	
		if (player.GetComponent<Collide>().collided) {

			Vector3 pos = transform.position;
			r.velocity = (pos - player.position) * - player.GetComponent<PlayerProperties>().velocityOfBump;
			
		} else {
		

			Vector3 pos = Input.mousePosition;
			if (Input.GetMouseButton(0)) {
				pos.z = distanceFromCamera;
				pos = cam.ScreenToWorldPoint (pos);
				r.velocity = (pos - player.position) * player.GetComponent<PlayerProperties>().velocityOfMovement;
			}
			
			if (Input.GetMouseButtonUp(0)) {
				r.velocity = Vector3.zero;
			}

		}
	}


}
