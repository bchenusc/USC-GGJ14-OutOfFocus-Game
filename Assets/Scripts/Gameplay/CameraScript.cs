using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	Transform player;

	
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").transform;

		// HACKS
		GameManager.Instance.ToString();
		InputManager.Instance.ToString();
		AudioManager.Instance.ToString();
		InputManager.Instance.ToString();
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
	}


}
