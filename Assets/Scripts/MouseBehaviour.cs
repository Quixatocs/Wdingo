using UnityEngine;
using System.Collections;

public class MouseBehaviour : MonoBehaviour {

	private Transform player;
	private PlayerProperties playerProperties;
	private Vector3 velocity = Vector3.zero;
	private Vector3 target;
	private Vector3 reboundTarget;
	Vector3 randomInAreaNearCollision = Vector3.zero;
	private float smoothTime;
	private float maxSpeed;
	private bool isFacingRight;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		target = player.position;
		playerProperties = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerProperties>();
		smoothTime = playerProperties.getMovementSmoothTime();
		maxSpeed = playerProperties.getMaxMovementVelocity();

	}


	void Update () {

		// Left Click Down
		if (Input.GetMouseButton(0) && !playerProperties.isCollided()) {
			facePlayer();
			move();
		} else if (playerProperties.isCollided()) {
			rebound();
		}

		// Left Click Up
		if (Input.GetMouseButtonUp(0)) {
			
		}
		

		// Right Click
	}

	private void move() {
		target = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
		target.z = 0f;
		transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime, maxSpeed);
		randomInAreaNearCollision = Random.insideUnitCircle * playerProperties.getDistanceRebounded();
		reboundTarget = transform.position + randomInAreaNearCollision;
	}

	private void rebound() { 
		transform.position = Vector3.SmoothDamp(transform.position, reboundTarget, ref velocity, smoothTime, maxSpeed/2);
	}

	private void facePlayer() {
		float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
		if ( mouseX < transform.position.x && isFacingRight 
			|| mouseX > transform.position.x && !isFacingRight) {
			flip();
		}
	}

	private void flip() {
		// Switch the way the player is labelled as facing
		isFacingRight = !isFacingRight;
		// Multiply the player's x local scale by -1
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}




}


