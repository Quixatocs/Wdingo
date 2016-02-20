using UnityEngine;
using System.Collections;

public class NemesisProperties : MonoBehaviour{

	//various changable attributes
	private bool collided;

	// player attributes
	private float maxMovementVelocity = 2.5f;
	private float stunnedTime = 2.0f;
	private int distanceRebounded = 20;


	// constants
	private const float MOVEMENT_SMOOTH_TIME = 0.5f; 



	//Getters and Setters
	public void setMaxMovementVelocity(float newMax) {
		this.maxMovementVelocity = newMax;
	}

	public float getMaxMovementVelocity() {
		return maxMovementVelocity;
	}

	//Getter and Setter for Collided bool 
	public void setCollided(bool newCollided) {
		this.collided = newCollided;
	}

	public bool isCollided() {
		return this.collided;
	}

	public float getMovementSmoothTime() {
		return MOVEMENT_SMOOTH_TIME;
	}

	public void setStunnedTime(float stunnedTime) {
		this.stunnedTime = stunnedTime;
	}

	public float getStunnedTime() {
		return stunnedTime;
	}

	public void setDistanceRebounded(int distance) {
		this.distanceRebounded = distance;
	}

	public int getDistanceRebounded() {
		return distanceRebounded;
	}






}
