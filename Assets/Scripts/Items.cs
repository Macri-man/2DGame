using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Items : ScriptableObject{

	public new string name;
	public string description;
	public Sprite icon;

	public void printItem(){
		Debug.Log(name + ": " + description + " Sprite :" + icon.name);
	}

}
