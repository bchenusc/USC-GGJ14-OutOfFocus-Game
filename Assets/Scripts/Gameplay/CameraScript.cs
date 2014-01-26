using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	Transform player;
	
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
	}
}
