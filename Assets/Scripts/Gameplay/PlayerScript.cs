using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private Vector2 dir;
	public float speed = 20.0f;

	// Use this for initialization
	void Start () {
		InputManager.Instance.RegisterOnKeyHeld(MovePlayer);
	}
	
	// Update is called once per frame
	void Update () {

	}


	void MovePlayer() {
		Vector2 movement = Vector2.zero;
		if (Input.GetKey(KeyCode.S)) {
			movement += new Vector2(0, -1);
		}
		if (Input.GetKey(KeyCode.W)) {
			movement += new Vector2(0, 1);
		}
		if (Input.GetKey(KeyCode.A)) {
			movement += new Vector2(-1, 0);
		}
		if (Input.GetKey(KeyCode.D)) {
			movement += new Vector2(1, 0);
		}
		movement = movement.normalized;
		dir = movement;

		Vector3 movement_dir = new Vector3(movement.x, movement.y, 0);
		transform.position += movement_dir * speed * Time.deltaTime;
	}
}
