using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FunctionIfVisible : MonoBehaviour {
	
	public Transform t_visibilityIcon;
	public bool isVisible = true;
	public LinkedList<Node> visibles = new LinkedList<Node>();


	public struct Node{
		public string id;
		public bool visibility;

		public Node(string myid, bool myvisibility){
			id = myid;
			visibility = myvisibility;
		}

		public void setId(bool b){

			visibility = b;
		}
	}

	public void AddNode(string gameId, bool visible){

		foreach (Node n in visibles){
			if (n.id == gameId){
				n.setId(visible);
				return;
			}
		}
		visibles.AddLast(new Node(gameId, visible));
	}

	public void RemoveNode(string gameId, bool visible){
		foreach (Node n in visibles){
			if (n.id == gameId){
				visibles.Remove(n);
			}
		}
	}

	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("IsSeen", 0.5f, 0.24f);
	}
	

	private void IsSeen(){
		t_visibilityIcon.renderer.enabled = !transform.GetComponent<Door> ().b_canOpen;
	}
	
}
