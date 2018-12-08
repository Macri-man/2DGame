using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Weapons { Hammer = 1, Rock, Fist };

public class PlayerCharacterController : MonoBehaviour {

    enum states { throws = 1, idle = 2, chase = 3, patrol = 4 };
    states state;

	public SoundTrigger deathSound;
    public GameObject weapon;
    public List<Sprite> weaponsSprites;
    public List<GameObject> weaponsObjects;
    [HideInInspector]
    public Weapons item;
	float horizontalMove = 0f;
    public float runSpeed = 10f;
	public Animator animate;
    [System.Serializable]
    public class StringEvent : UnityEvent<string> { }
    public StringEvent OnInputEvent;
	Vector3 startPosition;
	Vector3 checkPoint;
    Rigidbody2D rb;
    float forceJump = 200f;
    private bool grounded;
    private bool climbing;
    private bool canClimb;
    public Camera mainCamera;
    public Transform throwPosition;
    public GameObject throwObject;
    public int throwForce;
    private Vector2 velocity = Vector3.zero;
    float moveSmooth = .05f;
    [HideInInspector]
    public Climbing climbingwall;

    GameObject log;

    void Awake(){
        if (OnInputEvent == null)
            OnInputEvent = new StringEvent();
    }

	// Use this for initialization
	void Start () {
        this.startPosition = this.transform.position;
        rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

        if(climbing){
            return;
        }

        horizontalMove = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;

        switch (Input.inputString){
            case "1":
                item = Weapons.Hammer;
                weapon.GetComponent<SpriteRenderer>().sprite = weaponsSprites[0];
                //weapon = weaponObjects[0];
                OnInputEvent.Invoke(Input.inputString);
                break;
            case "2":
                item = Weapons.Rock;
                weapon.GetComponent<SpriteRenderer>().sprite = weaponsSprites[1];
                //weapon = weaponObjects[1];
                OnInputEvent.Invoke(Input.inputString);
                break;
            case "3":
                item = Weapons.Fist;
                weapon.GetComponent<SpriteRenderer>().sprite = null;
                //weapon = null;
                OnInputEvent.Invoke(Input.inputString);
                break;
        }

        if(Mathf.Sign(transform.localScale.x) != Mathf.Sign(horizontalMove) && horizontalMove != 0){
            Flip();
        }

        if (Input.GetMouseButtonDown(0) && item == Weapons.Rock){
            animate.SetTrigger("Throw");
        }

        if(Input.GetMouseButtonDown(0) && item == Weapons.Hammer){
            animate.SetTrigger("Hammer");
        }

        if (Input.GetMouseButtonDown(0) && item == Weapons.Fist && climbingwall != null){
            animate.SetBool("Climb",true);
            climbing = true;
            climbingwall.climb(this.transform);
        }

        if (Input.GetMouseButtonDown(0) && item == Weapons.Fist){
            animate.SetTrigger("PullLever");
        }

        //Debug.Log(Mathf.Abs(horizontalMove));
        rb.velocity = new Vector2(horizontalMove,rb.velocity.y);
        animate.SetFloat("Horizontal",Mathf.Abs(horizontalMove));
	}

    void FixedUpdate(){
        if (Input.GetButtonDown("Jump") && grounded){
            grounded = false;
            rb.AddForce(new Vector2(0f, forceJump));
        }
    }

    void throwRock(){
        Vector3 mouse = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        Vector3 directon = (mouse - this.throwPosition.transform.position).normalized;
        float angle = Mathf.Atan2(directon.y, directon.x) * Mathf.Rad2Deg;
        //Quaternion rotate = Quaternion.AngleAxis(angle,Vector3.forward);
        GameObject rock = Instantiate(throwObject, throwPosition.position, Quaternion.identity);
        rock.GetComponent<Rigidbody2D>().AddForce(directon * throwForce);
    }

    public void death(){
        deathSound.PlaySound();
        if (checkPoint == null){
            this.transform.position = this.startPosition;
        }else{
            this.transform.position = checkPoint;
        }
    }

    public void climb(){
        climbing = !climbing;
        animate.SetBool("Climb",false);
    }

    void onHammerHit(){
        Debug.Log("Hit");
        if(log != null){
            log.GetComponent<LogMovement>().moveLog = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log(other.gameObject.tag);
        Debug.Log(other.gameObject);

        switch(other.gameObject.tag){
            case "Log":
                log = other.gameObject;
            break;
            case "Climb":
                climbingwall = other.gameObject.GetComponent<Climbing>();
                climbingwall.objectplayer = this.gameObject;
                rb.velocity= new Vector2(0,0);
            break;
        }
        
    }
    
    void OnTriggerExit2D(Collider2D other){
        switch (other.gameObject.tag){
            case "Log":
                log = null;
                break;
            case "Climb":
                //climbingwall = other.gameObject.GetComponent<Climbing>();
                //climbingwall.objectplayer = this.gameObject;
            break;
        }
    }

    void onThrow(){
        //Debug.Log("Throw");
        Vector3 mouse = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        Vector3 directon = (mouse - this.throwPosition.transform.position).normalized;
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

    void OnCollisionEnter2D(Collision2D other) {
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
