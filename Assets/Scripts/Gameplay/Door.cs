using UnityEngine;
using System.Collections;

/*
 * How to use script:
 * 1. Place Door.cs on the Door prefab.
 * 2. In editor, link the DoorButton/Trigger as t_button.
 * 
 * @Brian Chen
 */


[RequireComponent (typeof (Animator))]
public class Door : MonoBehaviour {
	
	public Transform t_button;
	public bool b_canOpen = false;
	public Transform t_visibilityIcon;
	
	Animator animator;
	
	public bool b_IsOpen = false; //changeable from the inspector.

	void Awake(){
		transform.GetComponent<FunctionIfVisible> ().RegisterHasVision (CheckNotSeen);
	}

	void Start(){
		animator = transform.GetComponent<Animator>();
	}

	void CheckNotSeen(){
		if (!b_canOpen)
			t_visibilityIcon.renderer.enabled = true;
		b_canOpen = false;
	}

	public void IsSeen(){
		b_canOpen = true;

		t_visibilityIcon.renderer.enabled = false;
	}

	#region Used By Other Scripts
	public bool ToggleDoor(){
		if (!b_canOpen) return false;
		b_IsOpen = !b_IsOpen;
		if (b_IsOpen){
			gameObject.layer = 9;
		}else{
			gameObject.layer = 0;
		}
		transform.GetComponent<BoxCollider2D>().isTrigger = b_IsOpen;
		animator.SetBool("DoorOpen", b_IsOpen);
		return  true;
	}
	
	#endregion
	
}

