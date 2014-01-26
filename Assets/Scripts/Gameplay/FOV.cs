using UnityEngine;
using System.Collections;

public class FOV : MonoBehaviour {
	
	public Transform pivot;

	// Update is called once per frame
	void Update () {
		transform.position = pivot.position;

		Vector3 playerToMouse =  Vector3.Normalize(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
	}
}
