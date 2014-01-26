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
	}

	public void LevelEnd() {
		Debug.Log("Beat level " + currentLevel + "!");
		currentLevel++;
		if (currentLevel > furthestLevel) {
			furthestLevel = currentLevel;
		}
		// load next level after some delay
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
