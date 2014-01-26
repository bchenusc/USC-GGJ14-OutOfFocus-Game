using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformScript : MonoBehaviour {

	public bool startUp = false;
	public float speed = 1.5f;

	private Rigidbody2D rBody;
	private Transform collider1;
	private Transform collider2;

	void Awake () {
		rBody = gameObject.GetComponent<Rigidbody2D>();
		collider1 = transform.FindChild("Collider1");
		collider2 = transform.FindChild("Collider2");
	}

	// Use this for initialization
	void Start () {
		if (startUp) {
			rBody.velocity = Vector2.up * speed;
		} else {
			rBody.velocity = Vector2.up * -speed;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.transform == collider1 || other.transform == collider2) {
			speed *= -1;
			rBody.velocity = Vector2.up * speed;
		}
	}
}
