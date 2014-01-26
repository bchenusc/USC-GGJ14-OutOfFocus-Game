using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * How to use this class?
 * 1. Place the class on the player character with the colliders. 
 * 2. Ensure the player has a collider 2D and rigidbody 2D attached.
 * 3. Ensure the player is tagged as player and on the player layer.
 * 4. Customize float numbers located at the top of the script to tweak horizontal movement values.
 * 
 * Notes:
 * Class Handles:
 * 		LEFT GROUNDED
 * 		LEFT RISING
 * 		RIGHT GROUNDED
 * 		RIGHT RISING
 * 
 * Does NOT handle:
 * 		MOVING UP
 * 		MOVING DOWN
 * 		COLLISION
 * 
 * @Brian Chen
 * 
*/

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Animator))]

public class PlayerMove : MonoBehaviour {
	
	//Temporary variables -- DO NOT TOUCH (variables are set from playerstats.
	public float f_horiz = 0f;
	public float f_vertical = 0f;
	public float f_maxSpeed=4.0f; //horizontal only
	public enum Facing { none, moveUp, moveDown, moveLeft, moveRight, up, down, left, right};
	public Facing direction = Facing.down;
	//------------------------------------
	
	Animator animator;

	#region camcorder variables
	private GameObject cameraPrefab;
	private GameObject pickupCameraPrefab;
	private GameObject pickupCamera = null;
	private int numCameras = 0;
	private bool cameraNearby = false;
	private List<GameObject> nearbyCameras;
	#endregion

	void Awake () {
		cameraPrefab = Resources.Load<GameObject>("Prefabs/Camera");
		pickupCameraPrefab = Resources.Load<GameObject>("Prefabs/CameraPressSpace");
		nearbyCameras = new List<GameObject>();

		// HACKS to forcibly spawn these to singletons at the beginning of every level
		GameManager.Instance.ToString();
		AudioManager.Instance.ToString();
	}

	void Start () {
		//InputManager.Instance.RegisterOnKeyHeld(HandleInput);
		InputManager.Instance.RegisterOnKeyPressed(PlaceCamera);
		animator = transform.GetComponent<Animator>();
	}

	void Update(){

		Vector3 playerToMouse =  Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		playerToMouse.z = 0;
		if (Mathf.Abs(playerToMouse.x) > Mathf.Abs(playerToMouse.y)) {
			playerToMouse = new Vector3( Mathf.Sign(playerToMouse.x) * 1, 0, 0);
			if (playerToMouse.x > 0){
				direction = Facing.right;

			}else
			{
				direction = Facing.left;
			}
		}else {
			playerToMouse = new Vector3( 0, Mathf.Sign(playerToMouse.y) * 1, 0);

			if (playerToMouse.y > 0){
				direction = Facing.up;
			}else
			{
				direction = Facing.down;
			}
		}
		if (Mathf.Abs (f_horiz) < 0.1f && Mathf.Abs(f_vertical) < 0.1f){

			Face(direction);
		}

	}

	#region camcorder functions
	void PlaceCamera() {
		// 'F' to place a camcorder
		if (Input.GetKeyDown(KeyCode.F)) {
			if (numCameras > 0) {
				numCameras--;
				Instantiate(cameraPrefab, transform.position, Quaternion.identity);
			}
		}
		// 'Space' to pick up camcorder
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (nearbyCameras.Count > 0) {
				Destroy(nearbyCameras[0]);
				nearbyCameras.RemoveAt(0);
				numCameras++;
				if (nearbyCameras.Count == 0 && pickupCamera != null) {
					Destroy(pickupCamera);
					pickupCamera = null;
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Camcorder")) {
			if (nearbyCameras.Count == 0) {
				pickupCamera = Instantiate(pickupCameraPrefab, 
				                           new Vector3(other.transform.position.x + .4f, other.transform.position.y + .4f, 0),
				                           Quaternion.identity) as GameObject;
			}
			nearbyCameras.Add(other.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Camcorder")) {
			nearbyCameras.Remove(other.gameObject);
		}
		if (nearbyCameras.Count == 0 && pickupCamera != null) {
			Destroy(pickupCamera);
			pickupCamera = null;
		}
	}
	#endregion

	void FixedUpdate(){
	
		f_horiz = Input.GetAxisRaw("Horizontal"); //Gather input
		f_vertical = Input.GetAxisRaw ("Vertical"); // Gather vertical


		if (Mathf.Abs (f_horiz) < 0.1f && Mathf.Abs(f_vertical) < 0.1f) {
			rigidbody2D.velocity = Vector3.zero;
			//Debug.Log (direction);
			Face (direction);
		}else{
			rigidbody2D.velocity = new Vector3(f_horiz * f_maxSpeed, f_vertical * f_maxSpeed, 0);
			if (direction == Facing.up){
				Face(Facing.moveUp);
			}else
			if (direction == Facing.down){
				Face(Facing.moveDown);
			}else
			if (direction == Facing.left){
				Face(Facing.moveLeft);
			}else
			if (direction == Facing.right){
				Face(Facing.moveRight);
			}
		
		}
	}

	private void Face(Facing f){
		if (f == Facing.up) {
			//look up
			animator.SetInteger("Facing", 5);

		}
		else if (f==Facing.down){
			//look down
			animator.SetInteger("Facing", 6);

		}
		else if (f==Facing.left){
			//look left
			Vector3 theScale = transform.localScale;
			if (theScale.x > 0){
				theScale.x *= -1;
				transform.localScale = theScale;
			}
			animator.SetInteger("Facing", 7);

		}
		else if (f==Facing.right){
			//look right
			// Multiply the player's x local scale by -1.
			Vector3 theScale = transform.localScale;
			if (theScale.x < 0){
				theScale.x *= -1;
				transform.localScale = theScale;
			}

			animator.SetInteger("Facing", 8);
		}
		if (f == Facing.moveUp) {
			//look up
			animator.SetInteger("Facing", 1);
			
		}
		else if (f==Facing.moveDown){
			//look down
			animator.SetInteger("Facing", 2);
			
		}
		else if (f==Facing.moveLeft){
			//look left
			Vector3 theScale = transform.localScale;
			if (theScale.x > 0){
				theScale.x *= -1;
				transform.localScale = theScale;
			}
			animator.SetInteger("Facing", 3);
			
		}
		else if (f==Facing.moveRight){
			//look right
			// Multiply the player's x local scale by -1.
			Vector3 theScale = transform.localScale;
			if (theScale.x < 0){
				theScale.x *= -1;
				transform.localScale = theScale;
			}
			
			animator.SetInteger("Facing", 4);
		}
	}
}
