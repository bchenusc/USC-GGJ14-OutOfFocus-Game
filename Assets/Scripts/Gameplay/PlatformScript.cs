using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformScript : MonoBehaviour {

	public bool active;

	// Use this for initialization
	void Start () {
		active = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			//Move and do stuff
		}
	}
}
