using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	public Camera camera;
	public Transform player;
	public float distanceFromCamera;
	public Rigidbody2D rigidbody2D;

	public float maxMovementVelocity;




	void Start () {
		camera = Camera.main;
		player = transform;
		distanceFromCamera = Vector3.Distance (player.position, camera.transform.position);
		rigidbody2D = player.GetComponent<Rigidbody2D>();
		maxMovementVelocity = player.GetComponent<PlayerProperties>().maxMovementVelocity;

	}
	
	void Update () {

		if (!player.GetComponent<PlayerProperties>().getCollided()) {
			Vector3 pos = Input.mousePosition;
			if (Input.GetMouseButton(0)) {
				pos.z = distanceFromCamera;
				pos = camera.ScreenToWorldPoint (pos);
				rigidbody2D.velocity = Vector2.ClampMagnitude(
					(pos - player.position) * player.GetComponent<PlayerProperties>().velocityOfMovement, 
					maxMovementVelocity);
			}

		} else {
			rigidbody2D.velocity = Vector2.zero;
			if (Input.GetMouseButtonUp(0)) {
				player.GetComponent<PlayerProperties>().setCollided(false);
			}
		}
	}


}







