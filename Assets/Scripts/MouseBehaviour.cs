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

	void Start () {
		player = transform;
		target = player.position;
		playerProperties = player.GetComponent<PlayerProperties>();
		smoothTime = playerProperties.getMovementSmoothTime();
		maxSpeed = playerProperties.getMaxMovementVelocity();

	}


	void Update () {

		// Left Click Down
		if (Input.GetMouseButton(0) && !playerProperties.isCollided()) {
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



}


