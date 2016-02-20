using UnityEngine;
using System.Collections;

public class NemesisMasterAI : MonoBehaviour {

	private NemesisProperties nemesisProperties;
	private Transform target;
	private Vector3 velocity = Vector3.zero;
	private float dampTime = 5.0f;
	private float maxSpeed;
	private float smoothTime;


	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
		nemesisProperties = GameObject.FindGameObjectWithTag("GameManager").GetComponent<NemesisProperties>();
		smoothTime = nemesisProperties.getMovementSmoothTime();
		maxSpeed = nemesisProperties.getMaxMovementVelocity();

	}

	void Update () {
		transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime, maxSpeed);
	}
}
