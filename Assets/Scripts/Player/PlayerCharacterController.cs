using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Weapons { Hammer = 1, Rock, Fist };

public class PlayerCharacterController : MonoBehaviour {

    enum states { throws = 1, idle = 2, chase = 3, patrol = 4 };
    states state;
    public SoundTrigger itemChangeSound;
    public SoundTrigger jumpSound;
    public SoundTrigger hammerSwingSound;
    public SoundTrigger hammerHitLogSound;
    public SoundTrigger rockThrowSound;
    public SoundTrigger deathSound;
    public GameObject weapon;
    public List<Sprite> weaponsSprites;
    public List<GameObject> weaponsObjects;
    [HideInInspector]
    public Weapons item;
	float horizontalMove = 0f;
    public float runSpeed;
	public Animator animate;
    [System.Serializable]
    public class StringEvent : UnityEvent<string> { }
    public StringEvent OnInputEvent;
	Vector3 startPosition;
	public GameObject checkPoint;
    Rigidbody2D rb;
    public float forceJump;
    private bool grounded;
    private bool climbing;
    private bool canClimb;
    [HideInInspector]
    public bool notDead = true;
    public Camera mainCamera;
    public Transform throwPosition;
    public GameObject throwObject;
    public int throwForce;
    private Vector2 velocity = Vector3.zero;
    float moveSmooth = .05f;
    [HideInInspector]
    public Climbing climbingwall;
    [HideInInspector]
    public GameObject enemy;
    GameObject log;
    GameObject lever;
    Vector2 mouse;

   void Awake(){
        if (OnInputEvent == null)
            OnInputEvent = new StringEvent();

        if(Time.timeScale == 0){
            Time.timeScale = 1;
        }
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
    }

	void Start(){
        this.startPosition = this.transform.position;
        rb = GetComponent<Rigidbody2D>();
        switch ((int)item){
            case 1:
                OnInputEvent.Invoke("1");
                break;
            case 2:
                OnInputEvent.Invoke("2");
                break;
            case 3:
                OnInputEvent.Invoke("3");
                break;
        }
	}

    public void switchItem(Object newItem){
        switch (newItem.name){
            case "Hammer":
                item = Weapons.Hammer;
                weapon.GetComponent<SpriteRenderer>().sprite = weaponsSprites[0];
                //weapon = weaponObjects[0];
                //OnInputEvent.Invoke(Input.inputString);
                break;
            case "Rock":
                item = Weapons.Rock;
                weapon.GetComponent<SpriteRenderer>().sprite = weaponsSprites[1];
                //weapon = weaponObjects[1];
                //OnInputEvent.Invoke(Input.inputString);
                break;
            case "Fist":
                item = Weapons.Fist;
                weapon.GetComponent<SpriteRenderer>().sprite = null;
                //weapon = null;
                //OnInputEvent.Invoke(Input.inputString);
                break;
        }
    }

	void Update(){
        if(climbing || !notDead){
            return;
        }

        horizontalMove = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;

        switch (Input.inputString){
            case "1":
                item = Weapons.Hammer;
                weapon.GetComponent<SpriteRenderer>().sprite = weaponsSprites[0];
                //weapon = weaponObjects[0];
                OnInputEvent.Invoke(Input.inputString);
                itemChangeSound.PlaySound();
                break;
            case "2":
                item = Weapons.Rock;
                weapon.GetComponent<SpriteRenderer>().sprite = weaponsSprites[1];
                //weapon = weaponObjects[1];
                OnInputEvent.Invoke(Input.inputString);
                itemChangeSound.PlaySound();
                break;
            case "3":
                item = Weapons.Fist;
                weapon.GetComponent<SpriteRenderer>().sprite = null;
                //weapon = null;
                OnInputEvent.Invoke(Input.inputString);
                itemChangeSound.PlaySound();
                break;
        }


        if(Mathf.Sign(transform.localScale.x) != Mathf.Sign(horizontalMove) && horizontalMove != 0){
            Flip();
        }

        if (Input.GetMouseButtonDown(0) && item == Weapons.Rock){
            mouse = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            animate.SetTrigger("Throw");
            rockThrowSound.PlaySound();
        }

        if(Input.GetMouseButtonDown(0) && item == Weapons.Hammer){
            animate.SetTrigger("Hammer");
            hammerSwingSound.PlaySound();
        }

        if (Input.GetMouseButtonDown(0) && item == Weapons.Fist && climbingwall == null) {
            animate.SetTrigger("PullLever");
        }

        if (Input.GetMouseButtonDown(0) && item == Weapons.Fist && climbingwall != null){

            //Debug.Log((Vector2)this.transform.right);
            //Debug.Log((Vector2)climbingwall.endClimbPoint.transform.position);
            Vector2 temp = (Vector2)this.transform.position - (Vector2)climbingwall.endMovePoint.transform.position;
            temp.Normalize();
            int sign = (Vector2.Dot((Vector2)this.transform.right,temp) > 0) ? -1 : 1;
            //Debug.Log((Vector2)this.transform.position - (Vector2)climbingwall.endClimbPoint.transform.position);
            //Debug.Log((Vector2.Dot((Vector2)this.transform.right, temp) > 0) ? -1 : 1);
            //Debug.Log(Vector2.Dot(this.transform.right, (Vector2)climbingwall.endClimbPoint.transform.position));
            Debug.Log(sign);
            Debug.Log((int)(transform.localScale.x * 10));
            if (sign == (int)(transform.localScale.x * 10)){
                Debug.Log("Can Climb");
                animate.SetBool("Climb", true);
                rb.velocity = new Vector2(0, 0);
                rb.gravityScale = 0;
                climbing = true;
                climbingwall.climb(this.transform);
            }else{
                Debug.Log("Cannot Climb Climb");
            }

            //return;
        }

        //Debug.Log(Mathf.Abs(horizontalMove));
        rb.velocity = new Vector2(horizontalMove,rb.velocity.y);
        animate.SetFloat("Horizontal",Mathf.Abs(horizontalMove));
	}

    void FixedUpdate(){
      if(climbing || !notDead){
          return;
      }
        if (Input.GetButton("Jump") && grounded){
            grounded = false;
            rb.AddForce(new Vector2(0f, forceJump));
            jumpSound.PlaySound();
        }
    }

    public void death(){
      //this if-statement prevents the player being killed while dying :)
        if (notDead){
            deathSound.PlaySound();
            animate.SetBool("Climb",false);
            animate.SetTrigger("Death");
            notDead = false;
            if(climbingwall != null){
            Debug.Log("Wall");
              climbingwall.killClimbValues();
              climbingwall.objectplayer = null;
              climbingwall = null;
                Debug.Log(climbingwall);
            }
            climbing = false;
            rb.gravityScale = 1;
        }
    }

    public void onDeathFinished(){
        notDead = true;
        if (checkPoint == null){
            this.transform.position = this.startPosition;
        }else{
            this.transform.position = checkPoint.transform.position;
        }
    }
    public void endClimb(){
        climbing = !climbing;
        rb.gravityScale = 1;
        animate.SetBool("Climb",false);
    }

    void onHammerHit(){
        //Debug.Log("Hit");
        if(log != null){
            hammerHitLogSound.PlaySound();
            log.GetComponent<LogMovement>().fallSounds();
        }

        if(enemy != null){
            //Debug.Log("hits1");
            //if(Mathf.Sign(enemy.transform.localScale.x) == Mathf.Sign(transform.localScale.x)){
                //Debug.Log("hits");
                enemy.GetComponent<EnemyController>().death();
            //}
        }
    }

    public void pullLever(){
      if(lever != null){
          lever.GetComponent<Switches>().leverPulled();
      }
    }

    void OnTriggerEnter2D(Collider2D other){
        //Debug.Log(other.gameObject.tag);
        //Debug.Log(other.gameObject);
        switch(other.gameObject.tag){
          case "Log":
              log = other.gameObject;
          break;
          case "Lever":
              lever = other.gameObject;
          break;
            case "Climb":
                climbingwall = other.gameObject.GetComponent<Climbing>();
                climbingwall.objectplayer = this.gameObject;
            break;
            case "Enemy":
                enemy = other.gameObject;
            break;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        switch (other.gameObject.tag){
            case "Log":
                log = null;
                break;
            case "Lever":
                lever = null;
                break;
            case "Climb":
                //climbingwall.objectplayer = null;
                //climbingwall = null;
                //climbingwall = other.gameObject.GetComponent<Climbing>();
                //climbingwall.objectplayer = this.gameObject;
                break;
            case "Enemy":
                enemy = null;
            break;
        }
    }

    void onThrow(){
        Vector2 directon = (mouse - (Vector2)this.throwPosition.transform.position);
        directon.Normalize();
        float angle = Mathf.Atan2(directon.y, directon.x) * Mathf.Rad2Deg;
        //Quaternion rotate = Quaternion.AngleAxis(angle,Vector3.forward);
        GameObject rock = Instantiate(throwObject, throwPosition.position, Quaternion.identity);
        rock.GetComponent<Rigidbody2D>().AddForce(directon * throwForce);
        weapon.GetComponent<SpriteRenderer>().sprite = null;
    }

    void exitThrow(){
        //Debug.Log("ExitThrow");
        weapon.GetComponent<SpriteRenderer>().sprite = weaponsSprites[1];
    }

    void OnCollisionStay2D(Collision2D other) {
        switch (other.gameObject.tag){
            case "Ground":
                grounded = true;
                //rb.velocity = new Vector2(rb.velocity.x,0);
                break;
            case "Log":
                grounded = true;
                break;
        }
    }

    /*
    void OnCollisionEnter2D(Collision2D other) {
        //Debug.Log("Collision: " + other.gameObject);
        //Debug.Log("Collision: " + other.gameObject.tag);
        switch (other.gameObject.tag){
            case "Ground":
                grounded = true;
            //rb.velocity = new Vector2(rb.velocity.x,0);
            break;
            case "Log":
                grounded = true;
            break;
        }
    }
    */
    void OnCollisionExit2D(Collision2D other){
        switch(other.gameObject.tag){
            case "Ground":
                grounded = false;
            break;
            case "Log":
                grounded = false;
            break;
        }
    }
    private void Flip(){
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
