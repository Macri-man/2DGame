using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestAudio : MonoBehaviour {


    public SoundTrigger triggers;
    [System.Serializable]
    public class StringEvent : UnityEvent<string> { }

    public StringEvent OnHitEvent;

    private bool clicked = false;
    
    void Awake()
    {
        if (OnHitEvent == null){
            OnHitEvent = new StringEvent();
		        }
    }

    void OnMouseDown() {
        clicked = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
		Debug.Log(other.gameObject.name);
        //if(other.gameObject.name == "Rogue_01"){
        //    
        //}
        
        if (other.gameObject.name == "Rogue_01" && other.gameObject.GetComponent<playermovement>().item == 1 && clicked)
        {
            //OnHitEvent.Invoke("S1");
            triggers.PlaySound();
        }
	}

}
