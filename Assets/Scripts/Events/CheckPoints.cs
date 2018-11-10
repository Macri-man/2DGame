using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour {

	public List<Points> checkpoints;

	// Use this for initialization
	void Start () {
		if(checkpoints == null){
			Debug.LogWarning("NO Checkpoints");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
