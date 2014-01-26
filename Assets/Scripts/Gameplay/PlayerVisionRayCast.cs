using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerVisionRayCast : MonoBehaviour {

	public LayerMask fov_hit2;
	Door[] doors;
	public RaycastHit2D hit2;


	void Start(){
		doors = GameObject.FindObjectsOfType<Door>();


		InvokeRepeating ("CastRay", 0, 0.2f);
	}

	// Update is called once per frame
	void CastRay () {

		Vector3 playerToMouse =  Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		playerToMouse.z = 0;
		playerToMouse = Vector3.Normalize (playerToMouse);

		Debug.DrawRay (transform.position, playerToMouse * 3);
		hit2 = Physics2D.Raycast (transform.position , playerToMouse, 3.0f, fov_hit2);
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
					Debug.Log("HI" + gameObject.GetInstanceID());
					aDoor.b_canOpen = true;
				aDoor.transform.GetComponent<FunctionIfVisible>().AddNode(this.GetType().ToString(), false);
				}
				else {
					aDoor.b_canOpen = false;
				aDoor.transform.GetComponent<FunctionIfVisible>().AddNode(this.GetType().ToString(), true);
				}
			}
	}

	void NotHittingAnything(){
		foreach (Door aDoor in doors){
				aDoor.b_canOpen = false;
			aDoor.transform.GetComponent<FunctionIfVisible>().AddNode(this.GetType().ToString(), true);
		}
	}
}
