using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked2 : MonoBehaviour {

    [SerializeField]
    private ClickableObject clickedData;
    [SerializeField]
    private GameEvent[] events;

    [SerializeField]
    private EventsGame secondevent;

    public int state = 0;

    public void clicking()
    {
        Debug.Log(this.gameObject.name);

        this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

    }

    private void OnMouseDown()
    {
        //events.Raise();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Event Execute");
        state++;
        events[state].Raise();
    }
}
