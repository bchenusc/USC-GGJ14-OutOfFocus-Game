using UnityEngine;
using System.Collections;

public class VisionCameraScript : MonoBehaviour {

	public LayerMask fov_hit;
	public LayerMask fov_hit2;

	void Update(){
		CameraFOV ();
	}

	void CameraFOV(){

		RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up, 3.0f , fov_hit);
		RaycastHit2D hit2 = Physics2D.Raycast (transform.position, transform.up, 3.0f, fov_hit2);
		Debug.DrawRay (transform.position, transform.up * 3);
		if (hit!=null && hit.transform != null) {
			
			Vector3 distance = new Vector3(hit.point.x, hit.point.y, 0) - transform.position;
			distance.z = 0;
			transform.localScale = new Vector3 (Mathf.Clamp(Vector3.Magnitude(distance) / 3.0f, 0.05f, 1),  Mathf.Clamp(distance.magnitude / 3.0f, 0.05f, 1) , transform.localScale.z);
			
			HitSeeVaryingObject(hit);
			
		}else {
			transform.localScale = Vector3.one;
		}
		
		if (hit2 != null && hit2.transform != null){
			HitSeeVaryingObject(hit2);
		}
	}
	
	void HitSeeVaryingObject( RaycastHit2D hit){
		if (hit.transform.CompareTag("Door")){
			hit.transform.GetComponent<Door>().IsSeen();
		}
	}
}
