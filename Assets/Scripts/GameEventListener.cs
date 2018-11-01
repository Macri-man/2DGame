using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class GameEventListener : MonoBehaviour {
    
    public GameEvent gameEvent; 
    [SerializeField]
    public UnityEvent response; 
    public Items items;

    private void OnEnable() 
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable() 
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised() 
    {
        response.Invoke();
    }
}
