using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Clicked : MonoBehaviour {

    [SerializeField]
    private ClickableObject clickedData;
	[SerializeField]
    private GameEvent events;

	public int stat = 0;

	public void clicking(){
		//Debug.Log(this.gameObject.name);
        //Debug.Log(this.events.name);
        //Debug.Log("Clicked");

		this.gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;

    }

	private void OnMouseDown() {
		//events.Raise();
	}

	private void OnTriggerEnter2D(Collider2D other) {
		events.Raise();
	}

}
