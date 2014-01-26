using UnityEngine;
using System.Collections;

public class CameraVisionRayCast : MonoBehaviour {

	public LayerMask fov_hit2;
	Door[] doors;
	public RaycastHit2D hit2;
	PlatformScript_H[] platformH;
	PlatformScript_V[] platformV;
	
	void Start(){
		doors = GameObject.FindObjectsOfType<Door>();
		platformH = GameObject.FindObjectsOfType<PlatformScript_H> ();
		platformV = GameObject.FindObjectsOfType<PlatformScript_V> ();
		InvokeRepeating ("CastRay", 0, .1f);
	}
	
	// Update is called once per frame
	void CastRay () {

		//Debug.DrawRay (transform.position, transform.up* 3);
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

		foreach (PlatformScript_H aDoor in platformH){
			if (aDoor.transform == hit.transform){
				aDoor.Move();
			}
			else {
				if (Vector3.SqrMagnitude(aDoor.transform.position - transform.position)< 10)
					aDoor.Stop();
			}
		}
		
		foreach (PlatformScript_V aDoor in platformV){
			if (aDoor.transform == hit.transform){
				aDoor.Move();
			}
			else {
				if (Vector3.SqrMagnitude(aDoor.transform.position - transform.position)< 10)
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
