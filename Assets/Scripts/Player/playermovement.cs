using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playermovement : MonoBehaviour {

    public SoundTrigger deathSound;

    public CharacterController2D controller;
    public Camera mainCamera;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;

    [HideInInspector]
    public bool climbingMode = false;
    [HideInInspector]
    public bool startedClimbing = false;
    [HideInInspector]
    public bool climbingMid = false;

    public float climbingSpeed = 35f;
    private float playerGravity;
    bool crouch = false;
    bool throws = false;
    bool hammer = false;
    bool fist = false;

    public Animator animate;
    // Use this for initialization
    public Weapons item;

    [System.Serializable]
    public class StringEvent : UnityEvent<string> { }

    public StringEvent OnInputEvent;
    public UnityEvent changeCurser;

    public GameObject checkPoint;

    public Vector3 startPosition;

    public GameObject throwObject;
    public Transform throwPosition;

    public GameObject weapon;
    public List<Sprite> weaponSprite;


    void Awake()
    {
        if (OnInputEvent == null)
            OnInputEvent = new StringEvent();
    }

    void Start () {
        startPosition = this.transform.position;
        playerGravity = this.gameObject.GetComponent<Rigidbody2D>().gravityScale;

	}

	// Update is called once per frame
	void Update ()
  {
    verticalMove = 0f;
    this.gameObject.GetComponent<Rigidbody2D>().gravityScale = playerGravity;
    if(!climbingMode)
    {
      //Debug.Log("Climbing?");
      animate.SetBool("climbingOn", false);
    }
    if (Input.GetAxisRaw("Vertical") != 0f)
    {
      if(climbingMode && this.item == Weapons.Fist)
      {
          //Debug.Log("Climbing?");
          verticalMove = (Input.GetAxisRaw("Vertical") );// > 0f)?(1f):(-1f);
          if(verticalMove < 0f && controller.isGrounded())
          {
            //Debug.Log("Downward Move attempted while on ground.");
            //verticalMove = 0f;
            print ("translate called");
            transform.Translate(Vector3.up * 5 * Time.deltaTime);
          }
          //animate.SetFloat("speed", Mathf.Abs(verticalMove));
      }
      else
      {
        verticalMove = 0f;
      }
      if(verticalMove != 0f)
      {
        //Debug.Log("Climbing 2?");
        if(!startedClimbing && !climbingMid)
        {
          animate.SetBool("climbingOn", true);
          startedClimbing = true;
        }
        else if(startedClimbing && !climbingMid)
        {
          startedClimbing = false;
          climbingMid = true;
        }
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
      }
      else
      {
        if(startedClimbing || climbingMid)
        {
          animate.SetBool("climbingOn", false);
          startedClimbing = false;
          climbingMid = false;
        }
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = playerGravity;
      }
    }
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump") && !(climbingMode && climbingMid)){
            jump = true;
        }
        if (Input.GetButtonDown("crouch") && !(climbingMode && climbingMid)){
            crouch = true;
        } else if (Input.GetButtonUp("crouch")){
            crouch = false;
        }

        animate.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetMouseButtonDown(0) &&  item == Weapons.Hammer){
            //Instantiate();
        }


        switch (Input.inputString){
            case "1":
                item = Weapons.Hammer;
                weapon.GetComponent<SpriteRenderer>().sprite = weaponSprite[0];
                OnInputEvent.Invoke(Input.inputString);
                break;
            case "2":
                item = Weapons.Rock;
                weapon.GetComponent<SpriteRenderer>().sprite = weaponSprite[1];
                OnInputEvent.Invoke(Input.inputString);
                break;
            case "3":
                item = Weapons.Fist;
                OnInputEvent.Invoke(Input.inputString);
                break;
        }

        if (Input.GetMouseButtonDown(0) && !climbingMode && item == Weapons.Rock)
        {
            Vector3 mouse = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0;
            Vector3 directon = (mouse - this.throwPosition.transform.position).normalized;
            float angle = Mathf.Atan2(directon.y,directon.x) * Mathf.Rad2Deg;
            //Quaternion rotate = Quaternion.AngleAxis(angle,Vector3.forward);
            GameObject rock = Instantiate(throwObject,throwPosition.position,Quaternion.identity);
            rock.GetComponent<Rigidbody2D>().AddForce(directon * 140);
            animate.SetTrigger("isthrow");
        }
        else { animate.ResetTrigger("isthrow"); }
    }

    public void death(){
        Debug.Log("Death");
        deathSound.PlaySound();
        if(checkPoint == null){
            this.transform.position = this.startPosition;
        }else{
            this.transform.position = checkPoint.transform.position;
        }
    }

    public void OnCrouching(bool isCrouching){
        animate.SetBool("IsCrouching", isCrouching);
    }

    public bool compareWeapon(){
        return true;
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, verticalMove * Time.fixedDeltaTime);
        jump = false;
    }
}
