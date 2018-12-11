using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour {

	private Transform orb;

    private GameObject completeLevelMenu;

    public bool EndLevel;

    private bool notHit = true;

	// Use this for initialization
	void Start () {

        completeLevelMenu = GameObject.FindGameObjectWithTag("CompleteLevelMenu");
        Debug.Log(completeLevelMenu);
		orb = this.transform.GetChild(0);
        if(EndLevel){
            orb.GetComponent<SpriteRenderer>().color = new Color(0f, 0.65f, 1f, 0.7f);
        }else{
            orb.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.2f);
        }

        //Debug.Log(orb.name);
		//Debug.Log(orb.GetComponent<SpriteRenderer>().color);
	}

	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D other){

        if (other.gameObject.tag == "Player" && EndLevel){
            orb.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.8f);
            completeLevelMenu.SetActive(true);
            Time.timeScale = 0;
        }else if(other.gameObject.tag == "Player" && notHit){
            notHit = false;
            other.gameObject.GetComponent<PlayerCharacterController>().checkPoint = this.gameObject;
            orb.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.8f);
        }
    }
}
