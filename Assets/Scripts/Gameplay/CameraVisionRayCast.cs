using UnityEngine;
using System.Collections;

public class CameraVisionRayCast : MonoBehaviour {

	public LayerMask fov_hit2;
	Door[] doors;
	public RaycastHit2D hit2;
	
	void Start(){
		doors = GameObject.FindObjectsOfType<Door>();

		InvokeRepeating ("CastRay", 0, 0.2f);
	}
	
	// Update is called once per frame
	void CastRay () {

		Debug.DrawRay (transform.position, transform.up* 3);
		hit2 = Physics2D.Raycast (transform.position , transform.up, 3.0f, fov_hit2);
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
	}
	
	void NotHittingAnything(){
		foreach (Door aDoor in doors){
			aDoor.b_canOpen = false;
			aDoor.transform.GetComponent<FunctionIfVisible>().AddNode(this.GetType().ToString(), true);
		}
	}
}
