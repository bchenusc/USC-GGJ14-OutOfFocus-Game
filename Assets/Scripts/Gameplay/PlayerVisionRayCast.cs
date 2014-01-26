using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerVisionRayCast : MonoBehaviour {

	public LayerMask fov_hit2;
	Door[] doors;
	PlatformScript_H[] platformH;
	PlatformScript_V[] platformV;
	public RaycastHit2D hit2;


	void Start(){
		doors = GameObject.FindObjectsOfType<Door>();
		platformH = GameObject.FindObjectsOfType<PlatformScript_H> ();
		platformV = GameObject.FindObjectsOfType<PlatformScript_V> ();

		InvokeRepeating ("CastRay", 0, 0.2f);
	}

	// Update is called once per frame
	void CastRay () {

		Vector3 playerToMouse =  Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		playerToMouse.z = 0;
		playerToMouse = Vector3.Normalize (playerToMouse);

		//Debug.DrawRay (transform.position, playerToMouse * 4);
		hit2 = Physics2D.Raycast (transform.position , playerToMouse, 4.0f, fov_hit2);
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
				aDoor.transform.GetComponent<FunctionIfVisible>().AddNode(this.GetType().ToString(), false);
				}
				else {
					aDoor.b_canOpen = false;
				aDoor.transform.GetComponent<FunctionIfVisible>().AddNode(this.GetType().ToString(), true);
				}
			}

		foreach (PlatformScript_H aDoor in platformH){
			if (aDoor.transform == hit.transform){
				aDoor.Move();
			}
			else {

				aDoor.Stop();
			}
		}

		foreach (PlatformScript_V aDoor in platformV){
			if (aDoor.transform == hit.transform){
				aDoor.Move();
			}
			else {

				aDoor.Stop();
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
