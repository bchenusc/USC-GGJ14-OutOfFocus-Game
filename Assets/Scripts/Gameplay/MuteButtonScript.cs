using UnityEngine;
using System.Collections;

public class MuteButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		// Add Mute Stuff
		AudioManager.Instance.Mute();
	}
}
