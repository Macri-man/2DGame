using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class InteractHUB : MonoBehaviour {

	public Items item;
	public Text nameText;
	public Image image;
	public Image panel;

	void Start () {
		nameText.text = item.name;
		image.sprite = item.icon;
	}

	void Update() {
        /* if(Input.inputString == item.key){
            Debug.Log("clicked " + item.name);
			panel.color = Color.gray;
		}else{
            panel.color = Color.white;
		}
		*/
    }

	public void PressedKey(string input){
        if (input == item.key){
            //Debug.Log("clicked " + item.name);
            panel.color = Color.gray;
        }else{
            panel.color = Color.white;
        }
	}	
}
