using UnityEngine;
using System.Collections;

public class FOV : MonoBehaviour {
	
	public Transform pivot;

	// Update is called once per frame
	void Update () {
		transform.position = pivot.position;

		Vector3 playerToMouse =  Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		playerToMouse.z = 0;
		playerToMouse = Vector3.Normalize (playerToMouse);
		//Axis is Vector z

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
		if (other.transform != null){
			Debug.Log("hit something");
		}

	}
}
