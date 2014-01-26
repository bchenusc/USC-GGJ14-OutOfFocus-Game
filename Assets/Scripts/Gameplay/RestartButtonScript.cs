using UnityEngine;
using System.Collections;

public class RestartButtonScript : MonoBehaviour {

	void OnMouseDown() {
		GameManager.Instance.RestartLevel();
	}
}
