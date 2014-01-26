using UnityEngine;
using System.Collections;

public class WarpScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")){
			Destroy(other.transform.parent.FindChild("Vision").gameObject);
			other.transform.GetComponent<Animator>().SetInteger("Facing", 6);
			other.transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			other.transform.GetComponent<PlayerMove>().enabled = false;
			other.transform.position = transform.position + Vector3.up * 0.35f;
			GameManager.Instance.LevelEnd();
			AudioManager.Instance.PlaySoundEffect("levelEnd", gameObject);
		}
	}
}
