using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public SoundTrigger HitSound;
	public float speed = 1f;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += this.transform.right * speed * Time.deltaTime;
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		switch(other.gameObject.tag){
			case "Player":
				other.gameObject.GetComponent<playermovement>().death();
                //HitSound.PlaySound();
				Destroy(this);
			break;
			default:
                //HitSound.PlaySound();
                Destroy(this);
			break;

		}
	}
}
