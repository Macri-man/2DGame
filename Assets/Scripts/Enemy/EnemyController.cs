using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	bool FacingRight = true;
	public Transform[] points;
	public Transform targetPoint;
    public float interval;
	bool turn = false;

	float patrolSpeed = 1f;
    float runSpeed = 1f;

    Vector3 changeInPosition;

	public bool isChase;

	int position = 0;

    int sign;

	Rigidbody2D rb;

	 

	// Use this for initialization
	void Start () {
		if(points.Length < 0){
        	Debug.LogWarning("Need Points");
		}
		this.transform.position = points[0].transform.position;
        //rb = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isChase){
			sign = (Vector2.Dot((Vector2)this.transform.right,(Vector2)targetPoint.position) > 0)? 1:-1;
            //rb.transform.position = new Vector3(sign * runSpeed * Time.deltaTime,this.transform.position.y,0);
		}else{
            if (this.transform.position == points[position].transform.position){
                position = (position + 1) % points.Length;
                sign = (Vector2.Dot((Vector2)this.transform.right, (Vector2)points[position].transform.position) > 0)? 1 : -1;
                //Debug.Log(position);
                //Debug.Log(sign);
                //Debug.Log(transform.localScale.x*10);
                //Debug.DrawRay((Vector2)this.transform.position, this.transform.right, Color.red, 200f);
                //Debug.DrawRay((Vector2)this.transform.position, this.transform.up, Color.cyan, 200f);
				//if(sign != transform.localScale.x*10 ){
                //  Flip();
				//}
            }
            //rb.MovePosition(Vector2.Lerp(rb.transform.position, points[position].transform.position, Time.deltaTime * patrolSpeed));
            //Debug.Log(position);
			//Debug.Log(Vector3.Lerp(this.transform.position, points[position].transform.position, Time.deltaTime * patrolSpeed));
            //Debug.Log(this.transform.position == points[position].transform.position);
            this.transform.position = Vector3.Lerp(this.transform.position, points[position].transform.position,Time.deltaTime * patrolSpeed);
		}		
	}

    void Flip(){
        FacingRight = !FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

	void OnTriggerEnter2D(Collider2D other) {
		switch(other.gameObject.tag){
			case "Player":
                targetPoint = other.gameObject.transform;
                isChase = true;
			break;
			case "Spikes":
				Destroy(this);
			break;
		}
	}

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            targetPoint = null;
            isChase = false;
        }
    }
}
