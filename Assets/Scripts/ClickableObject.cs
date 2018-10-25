using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Clickable Object", menuName = "Click")]
public class ClickableObject : ScriptableObject {
    public new string name;
    public string description;
    public Sprite icon;
	public void print(){
		Debug.Log(name + ": " + description + "The Sprite: " +  icon.name);
	}
}


