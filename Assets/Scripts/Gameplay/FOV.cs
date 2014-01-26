using UnityEngine;
using System.Collections;

public class FOV : MonoBehaviour {
	
	public Transform pivot;
	public LayerMask fov_hit;

	// Update is called once per frame
	void Update () {
		transform.position = pivot.position;



		Vector3 playerToMouse =  Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		playerToMouse.z = 0;
		playerToMouse = Vector3.Normalize (playerToMouse);

		//Raycassting
		RaycastHit2D hit = Physics2D.Raycast (pivot.position, playerToMouse, 3.0f , fov_hit);
		Debug.DrawRay (pivot.position, playerToMouse * 3);
		if (hit!=null && hit.transform != null) {

			Vector3 distance = new Vector3(hit.point.x, hit.point.y, 0) - transform.position;
			distance.z = 0;
			transform.localScale = new Vector3 (Mathf.Clamp(Vector3.Magnitude(distance) / 3.0f, 0.05f, 1),  Mathf.Clamp(distance.magnitude / 3.0f, 0.05f, 1) , transform.localScale.z);
			Debug.Log (hit.transform + " , " + Vector3.Magnitude(distance) / 3);
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

	void OnTriggerEnter2D(Collider2D other){
		if (other.transform != transform && other.transform != pivot){

		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.transform != transform && other.transform != pivot){

		}
	}
}
