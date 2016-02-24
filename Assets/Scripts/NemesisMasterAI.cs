using UnityEngine;
using System.Collections;

public class NemesisMasterAI : MonoBehaviour {

	private NemesisProperties nemesisProperties;
	private Transform target;
	private Vector3 velocity = Vector3.zero;
	private float maxSpeed;
	private float smoothTime;
	private float lastNemesisIncrease;
	private float lastNemesisTeleport;
	private float nemesisSpeedIncrease = 0.25f;
	private bool isFacingRight;


	void Start () {
		transform.position = Random.insideUnitCircle * 40;
		target = GameObject.FindGameObjectWithTag("Player").transform;
		nemesisProperties = GameObject.FindGameObjectWithTag("GameManager").GetComponent<NemesisProperties>();
		smoothTime = nemesisProperties.getMovementSmoothTime();
		maxSpeed = nemesisProperties.getMaxMovementVelocity();

	}

	void Update () {

		faceNemesis();

		//teleport cooldown
		if (Time.time - lastNemesisTeleport >= 30.0f) {
			Debug.Log("Grim Distance : " + checkDistance());
			if (checkDistance() >= 60.0f) {
				teleportRandom();
			} else if ((checkDistance() >= 20.0f) && !(checkDistance() < 20.0f)) {
				teleportTowardsPlayer();
			}
			lastNemesisTeleport = Time.time;
		}
		//increases the nemesis properties cooldown
		if (Time.time - lastNemesisIncrease >= 10.0f) {
			nemesisSpeedUp();
			lastNemesisIncrease = Time.time;
		}
		transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime, maxSpeed);
	}

	private void nemesisSpeedUp() {
		SoundManager soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
		soundManager.playNemesisIncrease();
		nemesisProperties.changeMaxMovementVelocity(nemesisSpeedIncrease);
		maxSpeed = nemesisProperties.getMaxMovementVelocity();
		Debug.Log("Nemesis Speed Increased to : " + nemesisProperties.getMaxMovementVelocity());
	}

	private void teleportRandom() {
		playTeleportSound();
		transform.position = Random.insideUnitCircle * 200;
	}

	private void teleportTowardsPlayer() {
		Vector3 randomChange = Random.insideUnitSphere * 40;
		randomChange.z = 0;
		playTeleportSound();
		transform.position = target.position + randomChange;
	}

	private float checkDistance() {
		return Vector3.Distance(target.position, transform.position); 
	}

	private void playTeleportSound() {
		SoundManager soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
		soundManager.playNemesisTeleport();
	}

	private void faceNemesis() {
		float playerX = target.position.x;
		if ( playerX < transform.position.x && isFacingRight 
			|| playerX > transform.position.x && !isFacingRight) {
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
