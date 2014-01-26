using UnityEngine;
using System.Collections;

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

	
	void Start () {
		//InputManager.Instance.RegisterOnKeyHeld(HandleInput);
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

		Face(direction);

	}

	void FixedUpdate(){
	
		f_horiz = Input.GetAxisRaw("Horizontal"); //Gather input
		f_vertical = Input.GetAxisRaw ("Vertical"); // Gather vertical


		if (Mathf.Abs (f_horiz) < 0.1f && Mathf.Abs(f_vertical) < 0.1f) {
			direction = Facing.none;
			rigidbody2D.velocity = Vector3.zero;
				animator.SetInteger("Facing", 0);
		}else{
			rigidbody2D.velocity = new Vector3(f_horiz * f_maxSpeed, f_vertical * f_maxSpeed, 0);
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
