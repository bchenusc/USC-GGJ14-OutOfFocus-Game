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

		float angle = Mathf.Acos ((Vector3.Dot (playerToMouse, new Vector3(1,0,0) )));
		Debug.Log (angle);

		Quaternion rotation = Quaternion.AngleAxis (angle * 180 / Mathf.PI  - 90, Vector3.forward);

		transform.rotation = rotation;

	}
}
