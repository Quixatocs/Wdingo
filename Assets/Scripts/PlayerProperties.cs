﻿using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour{

	//various changable attributes
	private bool collided;

	public float velocityOfMovement = 2.0f;
	public float velocityOfBump = 0.5f;
	public float velocityOfDamp = 0.005f;

	//various switches


	//Getter and Setter for Collided bool 
	public void setCollided(bool collided) {
		this.collided = collided;
	}

	public bool getCollided() {
		return collided;
	}




}
