using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour {

    public SoundTrigger HitGround;
    public SoundTrigger HitTurret;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
    void OnTriggerEnter2D(Collider2D other) {

		Debug.Log(other.gameObject.tag);
		switch(other.gameObject.tag){
			case "Player":
                //HitSound.PlaySound();
			break;
            case "Tower":
                HitTurret.PlaySound();
                Destroy(this.gameObject);
                break;
            case "Ground":
                HitGround.PlaySound();
                Destroy(this.gameObject);
                break;
            case "Enemy":
                HitGround.PlaySound();
                Destroy(other.gameObject);
                break;
			default:
                //HitSound.PlaySound();
                //Destroy(this.gameObject);
			break;

		}
	}
}
