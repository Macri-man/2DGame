using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playermovement : MonoBehaviour {

    public CharacterController2D controller;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    public bool climbingMode = false;
    private bool startedClimbing = false;
    private float playerGravity;
    bool crouch = false;
    bool throws = false;
    bool hammer = false;
    bool fist = false;

    public Animator animate;
    // Use this for initialization
    public int item = 0;

    [System.Serializable]
    public class StringEvent : UnityEvent<string> { }

    public StringEvent OnInputEvent;
    public UnityEvent changeCurser;

    public Vector3 checkPoint;

    public Vector3 startPosition;


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
      if(climbingMode && this.item == 3)
      {
          //Debug.Log("Climbing?");
          verticalMove = (Input.GetAxisRaw("Vertical") );// > 0f)?(1f):(-1f);
          if(verticalMove < 0f && controller.isGrounded())
          {
            //Debug.Log("Downward Move attempted while on ground.");
            //verticalMove = 0f;
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
        if(!startedClimbing)
        {
          animate.SetBool("climbingOn", true);
          startedClimbing = true;
        }
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
      }
      else
      {
        if(startedClimbing)
        {
          animate.SetBool("climbingOn", false);
          startedClimbing = false;
        }
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = playerGravity;
      }
    }
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump") && !climbingMode){
            jump = true;
        }
        if (Input.GetButtonDown("crouch") && !climbingMode){
            crouch = true;
        } else if (Input.GetButtonUp("crouch")){
            crouch = false;
        }

        animate.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetMouseButtonDown(0) &&  item == 1){
            //Instantiate();
        }


        switch (Input.inputString){
            case "1":
                Debug.Log("Pressed One");
                item = 1;
                OnInputEvent.Invoke(Input.inputString);
                break;
            case "2":
                item = 2;
                OnInputEvent.Invoke(Input.inputString);
                break;
            case "3":
                item = 3;
                OnInputEvent.Invoke(Input.inputString);
                break;
        }

        if (Input.GetMouseButtonDown(0) && !climbingMode)
        {
            animate.SetTrigger("isthrow");
        }
        else { animate.ResetTrigger("isthrow"); }
    }

    public void death(){
        Debug.Log("Death");
        if(checkPoint == null){
            Debug.Log("no checkpoint");
            Debug.Log(this.gameObject.name);
            this.transform.position = this.startPosition;
        }else{
            Debug.Log("checkpoint");
            Debug.Log(this.gameObject.name);
            this.transform.position = checkPoint;
        }
    }

    public void OnCrouching(bool isCrouching){
        animate.SetBool("IsCrouching", isCrouching);
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, verticalMove * Time.fixedDeltaTime);
        jump = false;
    }
}
