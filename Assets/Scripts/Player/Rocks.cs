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
                Debug.Log(other.gameObject.tag);
                HitGround.PlaySound();
                other.gameObject.GetComponent<EnemyController>().hitByRock();
                Destroy(this.gameObject);
                break;
            case "Shurikens":
                HitGround.PlaySound();
                Destroy(this.gameObject);
                break;
			default:
                //HitSound.PlaySound();
                //Destroy(this.gameObject);
			break;

		}
	}
}
