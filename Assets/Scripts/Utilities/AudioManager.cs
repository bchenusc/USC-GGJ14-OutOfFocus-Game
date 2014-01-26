using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : Singleton<AudioManager> {
	protected AudioManager() {}

	AudioSource musicPlayer;

	Dictionary<string, AudioClip> music;
	Dictionary<string, AudioClip> sounds;

	void Awake () {
		musicPlayer = gameObject.AddComponent<AudioSource>();

		music = new Dictionary<string, AudioClip>();
		sounds = new Dictionary<string, AudioClip>();

		// Load music
		//music["MainTheme"] = Resources.Load<AudioClip>("Audio/Music/MainTheme");

		// Load sound effects
		//sounds["sword"] = Resources.Load<AudioClip>("Audio/Sounds/sword");
		sounds["button_end"] = Resources.Load<AudioClip>("Audio/Sounds/button_end");
		sounds["button_start"] = Resources.Load<AudioClip>("Audio/Sounds/button_start");
		sounds["levelEnd"] = Resources.Load<AudioClip>("Audio/Sounds/levelEnd");
	}
	
	public void Mute () {
		GameManager.Instance.player.GetComponent<AudioListener>().enabled = !GameManager.Instance.player.GetComponent<AudioListener>().enabled;
	}

	public void PlayMusic(string toPlay, float volume = 0.08f) {
		musicPlayer.Stop();
		try {
			musicPlayer.clip = music[toPlay];
		} catch(KeyNotFoundException e) {
			Debug.LogWarning("AudioManager::PlayMusic(" + toPlay + "): Clip of this name not found.");
			return;
		}
		musicPlayer.volume = volume;
		musicPlayer.Play();
	}

	public void StopMusic() {
		musicPlayer.Stop();
	}

	public void PlaySoundEffect(string toPlay, GameObject location, float volume = 1.0f) {
		try {
			PlayClipAtLocation(sounds[toPlay], location.transform.position, volume);
		} catch(KeyNotFoundException e) {
			Debug.LogWarning("AudioManager::PlaySoundEffect(" + toPlay + "): Clip of this name not found.");
			return;
		}
	}

	#region helper
	private AudioSource PlayClipAtLocation(AudioClip clip, Vector3 pos, float volume) {
		GameObject temp = new GameObject("OneShotAudio");
		temp.transform.position = pos;
		AudioSource source = temp.AddComponent<AudioSource>();
		source.clip = clip;
		source.volume = volume;
		source.Play();
		Destroy(temp, clip.length);
		return source;
	}
	#endregion
}
