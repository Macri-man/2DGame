using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestAudio : MonoBehaviour {

    [System.Serializable]
    public class StringEvent : UnityEvent<string> { }

    public StringEvent OnHitEvent;

    void Awake()
    {
        if (OnHitEvent == null){
            OnHitEvent = new StringEvent();
		        }
    }

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log(other.gameObject.name);
		if(other.gameObject.name == "Rogue_01"){
            OnHitEvent.Invoke("S1");
		}
	}
}
