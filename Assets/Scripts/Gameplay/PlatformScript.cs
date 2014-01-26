using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformScript : MonoBehaviour {

	public bool p_active;

	// Use this for initialization
	void Start () {
		p_active = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (p_active) {
			//Move and do stuff
		}
	}
}
