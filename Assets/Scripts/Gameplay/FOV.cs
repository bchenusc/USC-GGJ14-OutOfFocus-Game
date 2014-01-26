using UnityEngine;
using System.Collections;

public class FOV : MonoBehaviour {
	
	public Transform pivot;
	public LayerMask fov_hit;
	public RaycastHit2D hit;

	Door[] doors;
	
	void Start(){
		doors = GameObject.FindObjectsOfType<Door>();
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
	
	// Update is called once per frame
	void Update () {
		transform.position = pivot.position;



		Vector3 playerToMouse =  Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		playerToMouse.z = 0;
		playerToMouse = Vector3.Normalize (playerToMouse);

		//Raycassting
		hit = Physics2D.Raycast (pivot.position, playerToMouse, 4.0f , fov_hit);

		//Debug.DrawRay (pivot.position, playerToMouse * 3);
		if (hit!=null && hit.transform != null) {

			Vector3 distance = new Vector3(hit.point.x, hit.point.y, 0) - transform.position;
			distance.z = 0;
			transform.localScale = new Vector3 (Mathf.Clamp(Vector3.Magnitude(distance) / 4.0f, 0.05f, 1.5f),  Mathf.Clamp(distance.magnitude / 4.0f, 0.05f, 1.5f) , transform.localScale.z);

			HitSeeVaryingObject(hit);

		}else {
			transform.localScale = Vector3.one;
		}

		//Rotation
		float angle = Mathf.Acos ((Vector3.Dot (playerToMouse, Vector3.right )));
		if (angle > Mathf.PI && angle < Mathf.PI * 2) {
			angle =  2 *Mathf.PI - angle;
		}
		angle = angle *180/Mathf.PI - 90;

		if (Camera.main.ScreenToWorldPoint (Input.mousePosition).y < transform.position.y)
		{
			angle = 180 - angle;
		}

		Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);

		transform.rotation = rotation;

	}

}
