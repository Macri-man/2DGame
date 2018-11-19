using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour {

	private Transform orb;

	// Use this for initialization
	void Start () {
		orb = this.transform.GetChild(0);
        Debug.Log(orb.name);
		Debug.Log(orb.GetComponent<SpriteRenderer>().color);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("checkPoints");
            other.gameObject.GetComponent<playermovement>().checkPoint = this.transform.position;
            orb.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}
