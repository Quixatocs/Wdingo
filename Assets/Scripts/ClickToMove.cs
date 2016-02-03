using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	public Camera camera;
	public Transform player;
	public float distanceFromCamera;
	public Rigidbody2D rigidbody2D;
	public Vector2 velocity;




	void Start () {
		camera = Camera.main;
		player = transform;
		distanceFromCamera = Vector3.Distance (player.position, camera.transform.position);
		rigidbody2D = player.GetComponent<Rigidbody2D>();
		velocity = rigidbody2D.velocity;

	}
	
	void Update () {
		//checks for collided condition
		if (player.GetComponent<PlayerProperties>().getCollided()) {
			//stops the player if collided with a solid entity

			//need to add collided time meta here
			Vector3 pos = transform.position;

			velocity -= velocity * 1 / Time.deltaTime;

			//player.GetComponent<Collide>().collided = false;
		} else {

			Vector3 pos = Input.mousePosition;
			if (Input.GetMouseButton(0)) {
				pos.z = distanceFromCamera;
				pos = camera.ScreenToWorldPoint (pos);
				rigidbody2D.velocity = (pos - player.position) * player.GetComponent<PlayerProperties>().velocityOfMovement;
			}
			if (Input.GetMouseButtonUp(0)) {
				velocity = Vector2.zero;
				player.GetComponent<PlayerProperties>().setCollided(false);
			}
		}

	}






}
