using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerVisionRayCast : MonoBehaviour {

	public LayerMask fov_hit2;
	Door[] doors;

	void Start(){
		doors = GameObject.FindObjectsOfType<Door>();
	}

	// Update is called once per frame
	void FixedUpdate () {

		Vector3 playerToMouse =  Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		playerToMouse.z = 0;
		playerToMouse = Vector3.Normalize (playerToMouse);

		Debug.DrawRay (transform.position, playerToMouse * 3);
		RaycastHit2D hit2 = Physics2D.Raycast (transform.position , playerToMouse, 3.0f, fov_hit2);
		if (hit2 != null && hit2.transform != null){
			HitSeeVaryingObject(hit2);
		}
		else{
			NotHittingAnything();
		}
	}

	void HitSeeVaryingObject( RaycastHit2D hit){

			foreach (Door aDoor in doors){
				if (aDoor.transform == hit.transform){
					aDoor.b_canOpen = true;
					aDoor.transform.GetComponent<FunctionIfVisible>().isVisible = false;
				}
				else {
					aDoor.b_canOpen = false;
					aDoor.transform.GetComponent<FunctionIfVisible>().isVisible = true;
				}
			}
	}

	void NotHittingAnything(){
		foreach (Door aDoor in doors){
				aDoor.b_canOpen = false;
				aDoor.transform.GetComponent<FunctionIfVisible>().isVisible = true;
		}
	}
}
