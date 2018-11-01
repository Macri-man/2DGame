using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameState
{
    public string name;
    public int stateIndex;
    public int nextStateIndex;
    public GameEventListening eventListener;
}