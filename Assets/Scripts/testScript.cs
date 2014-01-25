using UnityEngine;
using System.Collections;

public class testScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InputManager.Instance.RegisterOnLeftMouseButtonDown(Bar);
		InputManager.Instance.RegisterOnLeftMouseButtonDown(PrintA);
		InputManager.Instance.RegisterOnRightMouseButtonDown(FooBar);
		InputManager.Instance.RegisterOnKeyPressed(MakeTimer);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Foo () {
		Debug.Log("Foo");
	}

	void Bar () {
		Debug.Log("Bar");
	}

	void PrintA() {
		Debug.Log("A");
	}

	void FooBar() {
		InputManager.Instance.DeregisterOnLeftMouseButtonDown(Bar);
	}

	void MakeTimer() {
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			TimerManager.Instance.Add("Timer",
			                          Foo,
			                          1.0f,
			                          true,
			                          5);
		}
	}
}
