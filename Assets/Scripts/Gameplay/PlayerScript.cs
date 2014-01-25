using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private Vector2 movement;
	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		InputManager.Instance.RegisterOnKeyPressed(MovePlayer);
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyUp(KeyCode.W)) {
			movement = Vector2.zero;
		}
		if (Input.GetKeyUp(KeyCode.A)) {
			movement = Vector2.zero;
		}
		if (Input.GetKeyUp(KeyCode.S)) {
			movement = Vector2.zero;
		}
		if (Input.GetKeyUp(KeyCode.D)) {
			movement = Vector2.zero;
		}

		Vector3 movement_dir = new Vector3(movement.x, movement.y, 0);
		transform.position += movement_dir * speed;
	}


	void MovePlayer() {
		movement = Vector2.zero;
		if (Input.GetKeyDown(KeyCode.S)) {
			movement += new Vector2 (0.0f, -0.1f);
		}
		if (Input.GetKeyDown(KeyCode.W)) {
			movement += new Vector2 (0.0f, 0.1f);
		}
		if (Input.GetKeyDown(KeyCode.A)) {
			movement += new Vector2(-0.1f, 0.0f);
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			movement += new Vector2(0.1f, 0.0f);
		}

	}
}
