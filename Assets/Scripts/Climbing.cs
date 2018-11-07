using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour {

	public Transform endClimbPoint;
	public Transform startClimbPoint;

	public float speed = 2f; 


	private bool climb = false;

	private bool clicked = false;

	GameObject objectplayer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(objectplayer == null){
			return;
		}
		if(climb){
        	objectplayer.transform.position = Vector3.Lerp(startClimbPoint.position,endClimbPoint.position,speed * Time.deltaTime);
		}
	}
    void OnMouseDown()
    {
        clicked = true;
		if(objectplayer.GetComponent<playermovement>().item == 3){
            climb = true;
		}
    }

    void OnMouseExit()
    {
        clicked = false;
    }

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("Enter");
        //Debug.Log(other.gameObject.name);
		if(other.gameObject.name == "Rogue_01"){
            //Debug.Log(other.gameObject.name);
            //Debug.Log(other.gameObject.GetComponent<playermovement>().item == 3);
            //climb = true;
            objectplayer = other.gameObject;
            //if (other.gameObject.GetComponent<playermovement>().item == 3 && clicked){
			//	Debug.Log("Climb");
            //   climb = true;
            //    
			//}
		}
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Rogue_01")
        {
            //climb = false;
        }
    }
}
