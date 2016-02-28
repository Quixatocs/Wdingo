using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour{

	//various changable attributes
	private bool collided = false;

	// player attributes
	private float maxMovementVelocity = 2.5f;
	private float stunnedTime = 2.0f;


	// constants
	private const float MOVEMENT_SMOOTH_TIME = 0.5f; 

	public void resetToDefaults() {
		setCollided(false);
		setMaxMovementVelocity(2.5f);
		setStunnedTime(2.0f);
	}

	//Getters and Setters
	public void setMaxMovementVelocity(float newMax) {
		this.maxMovementVelocity = newMax;
	}

	public float getMaxMovementVelocity() {
		return maxMovementVelocity;
	}

	public void changeMaxMovementVelocity(float amount) {
		float currentValue = getMaxMovementVelocity();
		setMaxMovementVelocity(currentValue + amount);
	}

	//Getter and Setter for Collided bool 
	public void setCollided(bool newCollidedState) {
		this.collided = newCollidedState;
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
