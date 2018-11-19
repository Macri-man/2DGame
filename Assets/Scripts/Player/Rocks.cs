using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
    void OnTriggerEnter2D(Collider2D other) {

		Debug.Log(other.gameObject.name);
		switch(other.gameObject.tag){
			case "Player":
                //HitSound.PlaySound();
			break;
			default:
                //HitSound.PlaySound();
				Debug.Log(other.gameObject.name);
                Destroy(this.gameObject);
			break;

		}
	}
}
