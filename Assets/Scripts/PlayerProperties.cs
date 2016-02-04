using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour{

	//various changable attributes
	private bool collided;

	public Vector3 minMovementVelocity = Vector3.zero;
//	public Vector3 maxMovementVelocity = Vector3.ClampMagnitude(maxMovementVelocity, 4.0f);
	public float dampVelocity = 0.05f;
	public float collidedTime = 0.5f;

	//various switches


	//Getter and Setter for Collided bool 
	public void setCollided(bool collided) {
		this.collided = collided;
	}

	public bool isCollided() {
		return this.collided;
	}

	public void setCollidedTime(float time) {
		this.collidedTime = time;
	}

	public float getCollidedTime() {
		return this.collidedTime;
	}




}
