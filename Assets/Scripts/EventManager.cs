using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MyEvent : UnityEvent<Color>
{
}

public class EventManager : MonoBehaviour
{

    private Dictionary<string, UnityEvent<Color>> eventDictionary;

    private static EventManager eventManager;

    private MyEvent myEvent;

    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent<Color>>();
        }
    }

    public static void StartListening(string eventName, UnityAction<Color> listener)
    {
        UnityEvent<Color> thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new MyEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction<Color> listener)
    {
        if (eventManager == null) return;
        UnityEvent<Color> thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName,Color color)
    {
        UnityEvent<Color> thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(color);
        }
    }
}
