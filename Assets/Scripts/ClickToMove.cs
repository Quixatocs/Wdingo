using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

//	private Camera camera;
//	private Transform player;
//	private float distanceFromCamera;
//	private Rigidbody2D rigidbody2D;
//	public float minMovementVelocity;
//	public float maxMovementVelocity;
//	public float dampVelocity;
//	public float velocityX;
//	public float velocityY;
//
//
//
//
//
//	void Start () {
//		camera = Camera.main;
//		player = transform;
//		distanceFromCamera = Vector3.Distance (player.position, camera.transform.position);
//		rigidbody2D = player.GetComponent<Rigidbody2D>();
//		minMovementVelocity = player.GetComponent<PlayerProperties>().minMovementVelocity;
//		maxMovementVelocity = player.GetComponent<PlayerProperties>().maxMovementVelocity;
//		dampVelocity = player.GetComponent<PlayerProperties>().dampVelocity;
//
//
//
//	}
//	
//	void Update () {


//		Vector3 target = Input.mousePosition;

		//USE THIS TO DO THE DAMPING
//		public float smoothTime = 0.3F;
//		private Vector3 velocity = Vector3.zero;
//		void Update() {
//			Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));
//			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
//		}


//		if (Input.GetMouseButton(0)) {
//			
//			target = Input.mousePosition;
//			target.z = distanceFromCamera;
//			target = camera.ScreenToWorldPoint(target);
//			rigidbody2D.velocity = Vector2.ClampMagnitude(
//				(target - player.position) * minMovementVelocity, 
//				maxMovementVelocity);
//		} 
//
//		velocityX = rigidbody2D.velocity.x;
//		velocityY = rigidbody2D.velocity.y;
//	}


}


