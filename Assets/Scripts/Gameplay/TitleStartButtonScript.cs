using UnityEngine;
using System.Collections;

public class TitleStartButtonScript : MonoBehaviour {

	void Awake () {
		// HACKS to forcibly spawn these to singletons at the beginning of every level
		GameManager.Instance.ToString();
		AudioManager.Instance.ToString();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		GameManager.Instance.currentLevel = 1;
		Application.LoadLevel("level1");
	}
}
