using UnityEngine;
using System.Collections;

public class PauseButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		foreach(Transform t in gameObject.transform) {
			t.gameObject.SetActive(!t.gameObject.activeInHierarchy);
		}
	}
}
