using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public GameObject thing;
	private Vector3 pos;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 point = Input.mousePosition;


		pos = camera.ScreenToWorldPoint(new Vector3(point.x, point.y, thing.transform.position.z));

		thing.transform.LookAt(pos, new Vector3(0,0,1));
	}

}
