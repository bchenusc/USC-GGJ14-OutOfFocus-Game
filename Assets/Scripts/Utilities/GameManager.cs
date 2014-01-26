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
	#endregion

	void Awake() {
		_player = GameObject.FindGameObjectWithTag("Player");
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

	}


}
