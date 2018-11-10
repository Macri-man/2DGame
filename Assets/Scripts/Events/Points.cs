using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log(other.gameObject.name);
		if(other.gameObject.name == "Rogue_01"){
            //Debug.Log("checkPoints");
            other.gameObject.GetComponent<playermovement>().checkPoint = this.transform.position;
		}
    }
}
