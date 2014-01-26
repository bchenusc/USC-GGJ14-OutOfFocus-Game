using UnityEngine;
using System.Collections;

public class FunctionIfVisible : MonoBehaviour {

	public Action CheckNotSeen;


	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("IsSeen", 0.5f, 0.1f);
	}
	

	private void IsSeen(){
		if (CheckNotSeen!=null){
			CheckNotSeen ();
		}
	}

	public bool RegisterHasVision(Action callback){
		try{
			CheckNotSeen += callback;
		return true;
		}catch {return false;}
	}

	public bool DeRegisterHasVision(Action callback){
		try{
			CheckNotSeen -= callback;
			return true;
		}catch {return false;}
	}
}
