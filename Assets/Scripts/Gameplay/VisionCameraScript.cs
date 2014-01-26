using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VisionCameraScript : MonoBehaviour {

	public LayerMask fov_hit;
	Door[] doors;
	public RaycastHit2D hit;

	void Start(){
		doors = GameObject.FindObjectsOfType<Door>();
	}

	void FixedUpdate(){

		hit = Physics2D.Raycast (transform.position, transform.up, 3.0f , fov_hit);

		if (hit!=null && hit.transform != null) {
			
			Vector3 distance = new Vector3(hit.point.x, hit.point.y, 0) - transform.position;
			distance.z = 0;
			transform.localScale = new Vector3 (Mathf.Clamp(Vector3.Magnitude(distance) / 3.0f, 0.05f, 1),  Mathf.Clamp(distance.magnitude / 3.0f, 0.05f, 1) , transform.localScale.z);

			HitSeeVaryingObject(hit);
			
		}else {
			transform.localScale = Vector3.one;
		}
	}

	void HitSeeVaryingObject( RaycastHit2D hit){

		foreach (Door aDoor in doors){
			if (aDoor.transform == hit.transform){
				//Debug.Log ("open" + hit.transform.GetInstanceID());
				aDoor.b_canOpen = true;
				aDoor.transform.GetComponent<FunctionIfVisible>().AddNode(this.GetType().ToString(), false);
			}
			else {
				//Debug.Log ("close" + hit.transform.GetInstanceID());
				aDoor.b_canOpen = false;
				aDoor.transform.GetComponent<FunctionIfVisible>().AddNode(this.GetType().ToString(), true);
			}
		}
	}
}
