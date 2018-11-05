using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Event in Game")]
public class EventsGame : ScriptableObject
{
    private List<GameEventListening> listeners = new List<GameEventListening>();

    public void Raise()
    {
        Debug.Log("Raised");
        Debug.Log(listeners.Count);
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListening listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListening listener)
    {
        listeners.Remove(listener);
    }
}
