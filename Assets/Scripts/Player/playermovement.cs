using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playermovement : MonoBehaviour {

    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    public Animator animate;
    // Use this for initialization
    public int item = 0;

    [System.Serializable]
    public class StringEvent : UnityEvent<string> { }

    public StringEvent OnInputEvent;

    void Awake()
    {
        if (OnInputEvent == null)
            OnInputEvent = new StringEvent();
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")){
            jump = true;
        }

        if (Input.GetButtonDown("crouch")){
            crouch = true;
        }else if (Input.GetButtonUp("crouch")){
            crouch = false;
        }

        animate.SetFloat("speed", Mathf.Abs(horizontalMove));


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
    }
    
    public void OnCrouching(bool isCrouching){
        animate.SetBool("IsCrouching", isCrouching);
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
