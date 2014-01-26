using UnityEngine;
using System.Collections;

public class WarpScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")){
			//other.gameObject.
			GameManager.Instance.LevelEnd();
			AudioManager.Instance.PlaySoundEffect("levelEnd", gameObject);
		}
	}
}
