using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {
	protected GameManager() {}

	#region const defines
	//private const int MAXCAMERAS = 1;
	private const int NUMLEVELS = 11;
	#endregion

	#region playerStats
	//private int numCameras = 0;
	private GameObject _player;
	public GameObject player {
		get { return _player; }
	}
	public int currentLevel = 0;
	private int furthestLevel = 0;
	public bool playerAlive { get; set; }
	#endregion

	void Awake() {
		_player = GameObject.FindGameObjectWithTag("Player");
		playerAlive = true;
		InputManager.Instance.RegisterOnKeyPressed(PlayerRestart);
	}

	public void LevelEnd() {
		Debug.Log("Beat level " + currentLevel + "!");
		currentLevel++;
		if (currentLevel > furthestLevel) {
			furthestLevel = currentLevel;
		}
		TimerManager.Instance.Add("nextLevel",
		                          LoadNextLevel,
		                          2.0f,
		                          false);
	}

	public void LoadNextLevel() {
		Application.LoadLevel(currentLevel);
	}

	public void PlayerRestart() {
		if (Input.GetKeyDown(KeyCode.R)) {
			RestartLevel();
		}
	}

	public void RestartLevel() {
		Application.LoadLevel(currentLevel);
	}

	void OnLevelWasLoaded(int level) {
		// assuming menu is level 0
		//if (level > 0) {
			_player = GameObject.FindGameObjectWithTag("Player");
			playerAlive = true;
		//}
	}


}
