using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Projectile : MonoBehaviour {

    public SoundTrigger HitGround;
    public SoundTrigger HitTurret;
	public float speed;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += this.transform.up * speed * Time.deltaTime;
		//rb.velocity = this.transform.up * speed;
	}

    public void setLocalScale(){
        Vector3 theScale = transform.localScale;
        theScale /= 2;
        transform.localScale = theScale;
    }


    void OnTriggerEnter2D(Collider2D other) {
		switch(other.gameObject.tag){
			case "Player":
				other.gameObject.GetComponent<playermovement>().death();
                //HitSound.PlaySound();
				Destroy(this.gameObject);
			break;
            case "Ground":
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
