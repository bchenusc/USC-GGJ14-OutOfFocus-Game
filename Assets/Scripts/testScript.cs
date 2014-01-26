using UnityEngine;
using System.Collections;

public class testScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InputManager.Instance.RegisterOnKeyPressed(PlayMusic);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void PlayMusic() {
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			Debug.Log("music");
			AudioManager.Instance.PlayMusic("MainTheme");
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			Debug.Log("sound effect");
			AudioManager.Instance.PlaySoundEffect("sword", this.gameObject);
		}
	}
}
