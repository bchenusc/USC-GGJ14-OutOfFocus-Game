using UnityEngine;
using System.Collections;

public class FunctionIfVisible : MonoBehaviour {
	
	public Transform t_visibilityIcon;
	public bool isVisible = true;

	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("IsSeen", 0.5f, 0.24f);
	}
	

	private void IsSeen(){
			t_visibilityIcon.renderer.enabled = isVisible;
	}
	
}
