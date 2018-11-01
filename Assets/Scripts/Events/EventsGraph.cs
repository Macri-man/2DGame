using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsGraph : MonoBehaviour {

    //public EventGraph events;

    [SerializeField]
    public List<GameState> states = new List<GameState>();

	//private GameState currentState;

	void Start () {
		//currentState = states[0];
        //Debug.Log("hello");

		for (int i = 0; i < states.Count; i++)
		{
            //states[i].eventListener.gameEvent(this);
		}
	}
}


