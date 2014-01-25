using UnityEngine;
using System.Collections;

public class testScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Timer.Instance.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			Timer.Instance.Add("Timer",
			                   Foo,
			                   1.0f,
			                   true,
			                   5);
		}
	}

	void Foo () {
		Debug.Log("Foo");
	}
}
