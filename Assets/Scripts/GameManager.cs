﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null; 
	public GameObject player;
	public GameObject tree1;


	float dice;

	public static int numberTrees;


	//Max number of Objects
	public int maxTrees = 100;

	void singletonThis() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}

	void Awake () {
		singletonThis();

		//spawn world here

		Instantiate(player);
		Instantiate(tree1);
	}

	
	void Start () 
	{
		
		//StartCoroutine(spawn());
	}
	
	IEnumerator spawn()
	{
		while (numberTrees < maxTrees)
		{
			spawnTrees();
			numberTrees++;
			yield return null;
		}
	}

	void spawnTrees(){

		// add a tree loading message

		
			dice = Random.Range (0,500);
			if (dice <= 99) {
				Instantiate(tree1);
			} else if (dice <= 199 && dice > 99) {
				Instantiate(tree1);
			} else if (dice <= 299 && dice > 199) {
				Instantiate(tree1);
			} else if (dice <= 399 && dice > 299) {
				Instantiate(tree1);
			} else if (dice <= 499 && dice > 399) {
				Instantiate(tree1);
			}

	}
}
