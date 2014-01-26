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
	public enum Facing { none, up, down, left, right};
	public Facing direction = Facing.down;
	//------------------------------------
	
	Animator animator;

	public Sprite upFacing;
	public Sprite downFacing;
	public Sprite leftFacing;
	public Sprite rightFacing;
	
	void Start () {
		//InputManager.Instance.RegisterOnKeyHeld(HandleInput);
		animator = transform.GetComponent<Animator>();
	}

	#region Private functions
	void FixedUpdate(){
	
		f_horiz = Input.GetAxisRaw("Horizontal"); //Gather input
		f_vertical = Input.GetAxisRaw ("Vertical"); // Gather vertical


		if (Mathf.Abs (f_horiz) < 0.1f && Mathf.Abs(f_vertical) < 0.1f) {
			direction = Facing.none;
			animator.SetInteger("Facing", 0);
			rigidbody2D.velocity = Vector3.zero;
		}else{
			rigidbody2D.velocity = new Vector3(f_horiz * f_maxSpeed, f_vertical * f_maxSpeed, 0);
		}


		//horizontal
		if (f_horiz > 0.1f) {
			direction = Facing.right;
		}
		else if (f_horiz < -0.1f){
			direction = Facing.left;
		}

		//vertical
		if (f_vertical > 0.1f) {
			direction = Facing.up;
		} else if (f_vertical < -0.1f) {
			direction = Facing.down;
		}

		if (direction != Facing.none)
			Face (direction);

	}

	private void Face(Facing f){
		if (f == Facing.up) {
			//look up
			if (animator.GetInteger("Facing") != 1){
			animator.SetInteger("Facing", 1);
			
			}
			transform.GetComponent<SpriteRenderer>().sprite = upFacing;
		}
		else if (f==Facing.down){
			//look down
			animator.SetInteger("Facing", 2);
			transform.GetComponent<SpriteRenderer>().sprite = downFacing;
		}
		else if (f==Facing.left){
			//look left
			Vector3 theScale = transform.localScale;
			if (theScale.x > 0){
				theScale.x *= -1;
				transform.localScale = theScale;
			}
			animator.SetInteger("Facing", 3);
			transform.GetComponent<SpriteRenderer>().sprite = leftFacing;
		}
		else if (f==Facing.right){
			//look right
			// Multiply the player's x local scale by -1.
			Vector3 theScale = transform.localScale;
			if (theScale.x < 0){
				theScale.x *= -1;
				transform.localScale = theScale;
			}

			animator.SetInteger("Facing", 4);
			transform.GetComponent<SpriteRenderer>().sprite = leftFacing;
		}
	}

	#endregion
}
