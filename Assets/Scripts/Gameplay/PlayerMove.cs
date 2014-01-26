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
	public enum Facing { up, down, left, right};
	//------------------------------------
	
	Animator animator;
	
	void Start () {
		//InputManager.Instance.RegisterOnKeyHeld(HandleInput);
		animator = transform.GetComponent<Animator>();
	}

	#region Private functions
	void FixedUpdate(){
	
		f_horiz = Input.GetAxisRaw("Horizontal"); //Gather input
		f_vertical = Input.GetAxisRaw ("Vertical"); // Gather vertical


		if (Mathf.Abs (f_horiz) < 0.1f && Mathf.Abs(f_vertical) < 0.1f) {
			rigidbody2D.velocity = Vector3.zero;
		}else{
			rigidbody2D.velocity = new Vector3(f_horiz * f_maxSpeed, f_vertical * f_maxSpeed, 0);
		}

		//vertical
		if (f_vertical > 0.1f) {

		} else if (f_vertical < -0.1f) {

		}

		//horizontal
		if (f_horiz > 0.1f) {

		}
		else if (f_vertical < -0.1f){

		}

	}

	private void Face(Facing f){
		if (f == Facing.up) {
			//look up
			animator.SetInteger("Facing", 0);
		}
		else if (f==Facing.down){
			//look down
			animator.SetInteger("Facing", 1);
		}
		else if (f==Facing.left){
			//look left
			animator.SetInteger("Facing", 2);
		}
		else if (f==Facing.right){
			//look right
			animator.SetInteger("Facing", 3);
		}
	}
	
	private void Animate(){
		//Check if there is an animator. If there is no animator, then do not animate
		if (animator == null || animator.runtimeAnimatorController == null)
			return;
		
		try
		{
			//Handle animation here.
			animator.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));
		}
		catch{}
	}
	#endregion
}
