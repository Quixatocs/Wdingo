using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour{

	//various changable attributes
	private bool collided;

	// player attributes
	private float maxMovementVelocity = 2.5f;
	private float stunnedTime = 2.5f;


	// constants
	private const float MOVEMENT_SMOOTH_TIME = 0.5f; 

	//Constructor
	public PlayerProperties() {
		
	}

	//various switches

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






}
