using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {

	public float rotateSpeed = 1f;
	public float speed =0.01f;

	float angle = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //angle += rotateSpeed;
		//this.transform.Rotate(0,0,angle * Time.deltaTime, Space.Self);
		this.transform.position += this.transform.right * speed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log(other.gameObject.tag);

        switch (other.gameObject.tag)
        {
            case "Player":
                //HitSound.PlaySound();
				other.gameObject.GetComponent<playermovement>().death();
				Destroy(this);
                break;
            case "Tower":
                //HitTurret.PlaySound();
                Destroy(this.gameObject);
                break;
            case "Ground":
                //HitGround.PlaySound();
                Destroy(this.gameObject);
                break;
            default:
                //HitSound.PlaySound();
                //Destroy(this.gameObject);
                break;

        }
		
	}
}
