using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New String Event", menuName = "2DGame/StringEvent")]
public class StringEvent : ScriptableObject {

	public string inputToEvent;

    [System.Serializable]
    public class SEvent : UnityEvent<string> { }

    public SEvent OnInputEvent;

	public void TriggerEvent(){
        if (OnInputEvent == null)
			return;
            //OnInputEvent = new SEvent();
		OnInputEvent.Invoke(inputToEvent);
	}
}
