using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public SoundTrigger deathSound;
    enum states {throws=1, idle=2, chase=3, patrol=4};
    states state;
	public Transform[] points;
	public GameObject targetPoint;
    public Animator animate;
    public GameObject shuriken;
    public Transform weapon;
    public float interval;
	bool turn = false;
    //[Range(0f,1f)]
	public float patrolSpeed;
    //[Range(0f, 1f)]
    public float chaseSpeed;
    Vector3 changeInPosition;
	int position = 0;
    int sign;
	Rigidbody2D rb;
    public bool doesChase;
    public bool Dead;
    public float throwInterval;
    public float turnAroundInterval;
    float timeStamp;
    public int health;
    int rockhits = 0;
    public float threshold;
    int layerMask;
    public float distance;
    public Transform startpoint;
    public float SpeedofShuriken;

	// Use this for initialization
	void Start () {
		if(points.Length < 0){
        	Debug.LogWarning("Need Points");
		}

        animate = GetComponent<Animator>();
        state = states.patrol;
        turnAround();
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        layerMask = LayerMask.GetMask("Foreground","Characters");
        
        targetPoint = GameObject.FindGameObjectWithTag("Player");
	}
	void Update() {

        if(Dead){
            return;
        }
        animate.SetInteger("State", (int)state);
        
    }

	void FixedUpdate(){

        if (Dead){
            return;
        }
        
        //animate.SetInteger("State",(int)state);
        Vector2 temp = this.targetPoint.transform.position - this.startpoint.position;
        temp.Normalize();
        RaycastHit2D hit = Physics2D.Raycast(startpoint.position, temp, distance, layerMask); //Physics2D.Linecast(startpoint.position, targetPoint.position,layerMask);
        Debug.DrawRay(startpoint.position, temp * distance, Color.blue, 1);
        Debug.DrawRay(startpoint.position, temp * hit.distance, Color.red, 1);

        if(hit.collider != null){
            if(hit.collider.tag == "Player" && (state != states.throws && state != states.chase)){
                hitDistances(hit);
            }
        }else{
            if(state == states.throws ||  state == states.chase){
                state = states.patrol;
            }
        }
        //Debug.Log(state);
        switch(state){
            case states.idle:
                if ((Time.time - timeStamp) > turnAroundInterval){
                    timeStamp = Time.time;
                    turnAround();
                    state = states.patrol;
                }
            break;
            case states.chase:
                rb.velocity = new Vector2(sign * chaseSpeed * Time.fixedDeltaTime, rb.velocity.y);
            break;
            case states.throws:
                //Debug.Log((Time.time - timeStamp));
                if ((Time.time - timeStamp) > throwInterval){
                    timeStamp = Time.time;
                    //Debug.Log("Throw");
                    animate.SetTrigger("throw");
                }
            break;
            case states.patrol:
                rb.velocity = new Vector2(sign * patrolSpeed * Time.fixedDeltaTime, rb.velocity.y);
                //Debug.Log(rb.velocity);
                /* (Mathf.Abs(points[position].transform.position.x - this.transform.position.x) < threshold){
                    position = (position + 1) % points.Length;
                    timeStamp = Time.time;
                    state = states.idle;
                } */
                break;
        }
	}

    void hitDistances(RaycastHit2D hitter){
        int sign = (Vector2.Dot(this.transform.right, (Vector2)this.targetPoint.transform.position) > 0) ? -1 : 1;
        if(sign != (int)(transform.localScale.x * 10)){
            return;
        }
        if(doesChase){
            state = states.chase;
            timeStamp = Time.time;
        }else{
            //turnAroundTarget();
            state = states.throws;
            timeStamp = Time.time;
            animate.SetTrigger("throw");
            //animate.Play("Idle");
        }
    }

    void onThrow(){
        //Debug.Log("resetting Trigger");
        timeStamp = Time.time;
        Vector2 temp = this.targetPoint.transform.position - this.transform.position;
        temp.Normalize();
        GameObject shurikenObject = Instantiate(shuriken, weapon.position,Quaternion.AngleAxis(Mathf.Atan2(temp.y, temp.x) * Mathf.Rad2Deg, Vector3.forward));
        shurikenObject.GetComponent<Shuriken>().speed = SpeedofShuriken;
        animate.ResetTrigger("throw");
        animate.Play("Idle");
    }

    void turnAround(){
        sign = (Vector2.Dot((Vector2)this.transform.position - (Vector2)points[position].transform.position, (Vector2)points[position].transform.position) > 0) ? -1 : 1;
        if(sign != (int)(transform.localScale.x*10)){
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void turnAroundTarget(){
        sign = (Vector2.Dot((Vector2)this.transform.position - (Vector2)this.targetPoint.transform.position, (Vector2)points[position].transform.position) > 0) ? -1 : 1;
        if (sign != (int)(transform.localScale.x * 10)){
        //if (Mathf.Sign(transform.localScale.x) != Mathf.Sign(this.targetPoint.transform.localScale.x)){
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    public void hitByRock(){
        rockhits++;
        animate.SetTrigger("Hit");
        turnAroundTarget();
        if (doesChase){
            state = states.chase;
            timeStamp = Time.time;
        }else{
            state = states.throws;
            timeStamp = Time.time;
            animate.SetTrigger("throw");
        }
        if(rockhits == health){
            death();
        }
    }

    public void death(){
        if (!Dead){
            deathSound.PlaySound();
            //isDying = true;
            animate.SetTrigger("Death");
            Dead = true;
        }
        
        //animate.Play("EnemyDeath");
        //Destroy(this.gameObject);
    }

    void onDeathFinished(){
      Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(Dead){
            return;
        }
        switch(other.gameObject.tag){
            case "PatrolPoints":
                if (points[position].gameObject == other.gameObject){
                    position = (position + 1) % points.Length;
                    timeStamp = Time.time;
                    state = states.idle;
                }
            break;
            case "Spikes":
                death();
            break;
        }

    }
}
