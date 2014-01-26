using UnityEngine;
using System.Collections;

public class MuteButtonScript : MonoBehaviour {
	private bool _muted = false;
	private Sprite soundOn;
	private Sprite soundOff;

	void Awake () {
		soundOn = Resources.Load<Sprite>("Icons/soundon");
		soundOff = Resources.Load<Sprite>("Icons/soundoff");
	}

	public bool muted {
		get { return _muted; }
	}

	void OnMouseDown() {
		// Add Mute Stuff
		AudioManager.Instance.Mute();
		_muted = !_muted;
		if (_muted) {
			gameObject.GetComponent<SpriteRenderer>().sprite = soundOff;
		} else {
			gameObject.GetComponent<SpriteRenderer>().sprite = soundOn;
		}
	}
}
