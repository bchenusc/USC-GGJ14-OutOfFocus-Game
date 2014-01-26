using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VisionCameraScript : MonoBehaviour {

	public LayerMask fov_hit;
	Door[] doors;

	void Start(){
		doors = GameObject.FindObjectsOfType<Door>();
	}

	void FixedUpdate(){

		RaycastHit2D hit = Physics2D.Raycast (transform.position, -transform.up, 3.0f , fov_hit);

		if (hit!=null && hit.transform != null) {
			
			Vector3 distance = new Vector3(hit.point.x, hit.point.y, 0) - transform.position;
			distance.z = 0;
			transform.localScale = new Vector3 (Mathf.Clamp(Vector3.Magnitude(distance) / 3.0f, 0.05f, 1),  Mathf.Clamp(distance.magnitude / 3.0f, 0.05f, 1) , transform.localScale.z);
			
		}else {
			transform.localScale = Vector3.one;
		}
	}
}
