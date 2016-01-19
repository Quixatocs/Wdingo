using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	public Camera cam;
	public Transform player;
	public float distanceFromCamera;
	public Rigidbody2D rigidbody2d;



	void Start () {
		cam = Camera.main;
		player = transform;
		distanceFromCamera = Vector3.Distance (player.position, cam.transform.position);
		rigidbody2d = player.GetComponent<Rigidbody2D>();

	}
	
	void Update () {
		if (player.GetComponent<PlayerProperties>().getCollided()) {
			Vector3 pos = transform.position;
			rigidbody2d.velocity = Vector3.zero;
			rigidbody2d.velocity = (pos - player.position) * - player.GetComponent<PlayerProperties>().velocityOfBump;
			//player.GetComponent<Collide>().collided = false;
		} else {
			Vector3 pos = Input.mousePosition;
			if (Input.GetMouseButton(0)) {
				pos.z = distanceFromCamera;
				pos = cam.ScreenToWorldPoint (pos);
				rigidbody2d.velocity = (pos - player.position) * player.GetComponent<PlayerProperties>().velocityOfMovement;
			}
			if (Input.GetMouseButtonUp(0)) {
				rigidbody2d.velocity = Vector3.zero;
				player.GetComponent<PlayerProperties>().setCollided(false);
			}
		}

	}






}
