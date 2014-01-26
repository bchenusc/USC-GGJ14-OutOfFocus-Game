using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformScript_V : MonoBehaviour {

	public bool startUp = false;
	public float speed = 1.5f;
	public Sprite upSprite;
	public Sprite downSprite;
	public GameObject[] sidePlatforms;

	private Rigidbody2D rBody;
	private SpriteRenderer sRenderer;
	private Transform collider1;
	private Transform collider2;

	void Awake () {
		sRenderer = gameObject.GetComponent<SpriteRenderer>();
		rBody = gameObject.GetComponent<Rigidbody2D>();
		collider1 = transform.FindChild("Collider1");
		collider2 = transform.FindChild("Collider2");
	}

	// Use this for initialization
	void Start () {
		if (startUp) {
			rBody.velocity = Vector2.up * speed;
			sRenderer.sprite = upSprite;
		} else {
			rBody.velocity = Vector2.up * -speed;
			sRenderer.sprite = downSprite;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.transform == collider1 || other.transform == collider2) {
			speed *= -1;
			rBody.velocity = Vector2.zero;
			TimerManager.Instance.Add(gameObject.GetInstanceID() + "waitToMove", Move, 2.0f, false);
			if (speed > 0) {
				sRenderer.sprite = upSprite;
				if (sidePlatforms != null) {
					foreach (GameObject p in sidePlatforms) {
						p.GetComponent<SpriteRenderer>().sprite = upSprite;
					}
				}
			} else {
				sRenderer.sprite = downSprite;
				if (sidePlatforms != null) {
					foreach (GameObject p in sidePlatforms) {
						p.GetComponent<SpriteRenderer>().sprite = downSprite;
					}
				}
			}
		} 
		if (other.CompareTag("Player") && GameManager.Instance.playerAlive) {
			other.transform.parent.parent = transform;
			other.gameObject.GetComponent<PlayerMove>().onPlatform = true;
		}
		if (other.CompareTag("Camcorder")) {
			other.transform.parent = transform;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag("Player")) {
			other.transform.parent.parent = null;
			other.gameObject.GetComponent<PlayerMove>().onPlatform = false;
		}
		if (other.CompareTag("Camcorder")) {
			other.transform.parent = null;
		}
	}

	void Move() {
		rBody.velocity = Vector2.up * speed;
	}
}
