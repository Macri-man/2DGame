using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public SoundTrigger deathSound;
    enum states {throws=1, idle=2, chase=3, patrol=4};
    states state;
	public Transform[] points;
	public Transform targetPoint;
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
    public float throwInterval;
    public float turnAroundInterval;
    float timeStamp;
    public int health;
    int rockhits = 0;
    public float threshold;
    int layerMask;
    int distance = 10;
    public int radius; 
    public Transform startpoint;

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
	}
	
	// Update is called once per frame
	void FixedUpdate(){
        animate.SetInteger("State",(int)state);

        RaycastHit2D hit =  Physics2D.Linecast(startpoint.position, targetPoint.position,layerMask);
        Vector2 temp = this.targetPoint.position - this.startpoint.position;
        if(hit.collider.tag == "Player"){
            if(doesChase){
                state = states.chase;
                timeStamp = Time.time;
            }else{
                state = states.throws;
                timeStamp = Time.time;
            }
            Debug.DrawRay(startpoint.position, temp * hit.distance, Color.red);
            Debug.Log("does hit");
        }else{
            Debug.DrawRay(startpoint.position, temp * 100, Color.black);
            Debug.Log("does not hit: " + hit.distance);
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
                if ((Time.time - timeStamp) > turnAroundInterval){
                    Debug.Log("Throw");
                    timeStamp =  Time.time;
                    temp = this.targetPoint.position - this.transform.position;
                    temp.Normalize();
                    GameObject kill = Instantiate(shuriken, weapon.position,
                    Quaternion.AngleAxis(Mathf.Atan2(temp.y, temp.x) * Mathf.Rad2Deg, Vector3.forward));
                    animate.SetTrigger("throw");
                    Debug.Log(kill);
                }
            break;
            case states.patrol:
                rb.velocity = new Vector2(sign * patrolSpeed * Time.fixedDeltaTime, rb.velocity.y);
                /*(Mathf.Abs(points[position].transform.position.x - this.transform.position.x) < threshold){
                    position = (position + 1) % points.Length;
                    timeStamp = Time.time;
                    state = states.idle;
                } */
                break;
        }
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void onThrow(){
        //Debug.Log("reseting Trigger");
        timeStamp = Time.time;
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
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    public void hitByRock(){
        rockhits++;
        if(rockhits == health){
            death();
        }
    }

    public void death(){
        deathSound.PlaySound();
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other) {
        switch(other.gameObject.tag){
            case "Player":
                other.gameObject.GetComponent<PlayerCharacterController>().death();
                state = states.patrol;
                turnAround();
            break;
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
