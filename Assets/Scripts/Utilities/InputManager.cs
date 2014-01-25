using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * How to use:
 * 1. 
 * 
 * Notes:
 * 1. 
 * 
 * @ Matthew Pohlmann
 * 
*/

public class InputManager : Singleton<InputManager> {
	protected InputManager() {}

	#region actions
	private Action OnLeftMouseButtonDown;
	private Action OnRightMouseButtonDown;
	private Action OnKeyPressed;
	#endregion
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
			OnLeftMouseButtonDown();
		if (Input.GetMouseButtonDown(1))
			OnRightMouseButtonDown();
		if (Input.anyKeyDown)
			OnKeyPressed();
	}

	#region register functions
	public void RegisterOnLeftMouseButtonDown(Action a) {
		OnLeftMouseButtonDown += a;
	}

	public void RegisterOnRightMouseButtonDown(Action a) {
		OnRightMouseButtonDown += a;
	}

	public void RegisterOnKeyPressed(Action a) {
		OnKeyPressed += a;
	}
	#endregion

	#region deregister functions
	public void DeregisterOnLeftMouseButtonDown(Action a) {
		OnLeftMouseButtonDown -= a;
	}
	
	public void DeregisterOnRightMouseButtonDown(Action a) {
		OnRightMouseButtonDown -= a;
	}

	public void DeregisterOnKeyPressed(Action a) {
		OnKeyPressed -= a;
	}
	#endregion

	//private class 
}
