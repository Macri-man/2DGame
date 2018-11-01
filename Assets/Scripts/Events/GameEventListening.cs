using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameEventListening : MonoBehaviour
{
    public Items itemToUse;
    public EventsGame gameEvent;
    [SerializeField]
    public UnityEvent response;

    private void OnEnable()
    {
		Debug.Log("Hello");
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
		Debug.Log("Now Invoke");
        response.Invoke();
    }
}
