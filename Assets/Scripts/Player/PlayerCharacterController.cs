using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Weapons { Hammer = 1, Rock, Fist };

public class PlayerCharacterController : MonoBehaviour {

	public SoundTrigger deathSound;
    public GameObject weapon;
    public List<Sprite> weaponSprite;
    [HideInInspector]
    public Weapons item;
	float horizontalMove = 0;
	public Animator animate;

    [System.Serializable]
    public class StringEvent : UnityEvent<string> { }
    public StringEvent OnInputEvent;
	Vector3 startPosition;
	Vector3 checkPoint;

    void Awake(){
        if (OnInputEvent == null)
            OnInputEvent = new StringEvent();
    }

	// Use this for initialization
	void Start () {
        this.startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

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


        //animate.SetFloat("Vertical",);
        //animate.SetFloat("Horizontal",);

		
	}

    public void death(){
        Debug.Log("Death");
        deathSound.PlaySound();
        if (checkPoint == null){
            this.transform.position = this.startPosition;
        }else{
            this.transform.position = checkPoint;
        }
    }

    void FixedUpdate(){
        //controller.UpdateAnimator(horizontalMove * Time.fixedDeltaTime, climb, jump, verticalMove * Time.fixedDeltaTime);
        //jump = false;
    }

}
