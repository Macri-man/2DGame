using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {

    public SoundTrigger HitMetal;

	public float rotateSpeed;
    [HideInInspector]
	public float speed;

    public GameObject shuriken;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
        //angle += rotateSpeed;
        shuriken.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime, Space.Self);
        //Debug.Log(rb.velocity);
        //Debug.Log(this.transform.right * speed * Time.deltaTime);
        //rb.velocity = this.transform.right * speed * Time.deltaTime;
        //rb.MovePosition(this.transform.position += this.transform.right * speed * Time.deltaTime);
		//this.transform.Rotate(0,0,angle * Time.deltaTime, Space.Self);
		//this.transform.position += this.transform.right * speed * Time.deltaTime;
	}

    void FixedUpdate() {
        Debug.Log(rb.velocity);
        rb.velocity = this.transform.right * speed * Time.deltaTime;
    }

	void OnTriggerEnter2D(Collider2D other) {

		//Debug.Log(other.gameObject.tag);

        switch (other.gameObject.tag){
            case "Player":
                //HitSound.PlaySound();
								//This ensures that the projectile won't be obliterated if the player is already dying
								//if(!(other.gameObject.GetComponent<PlayerCharacterController>().isDying))
								//{
									other.gameObject.GetComponent<PlayerCharacterController>().death();
									Destroy(this.gameObject);
								//}
                break;
            case "Tower":
                //HitTurret.PlaySound();
                //Destroy(this.gameObject);
                break;
            case "Ground":
                //HitGround.PlaySound();
                Destroy(this.gameObject);
                break;
            case "Rocks":
                HitMetal.PlaySound();
                Destroy(this.gameObject);
                break;
            default:
                //HitSound.PlaySound();
                //Destroy(this.gameObject);
                break;

        }

	}
}
