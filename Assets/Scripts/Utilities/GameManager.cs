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
	private int currentLevel = 0;
	private int furthestLevel = 0;
	#endregion

	// Update is called once per frame
	void Update () {
		
	}


}
