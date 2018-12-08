using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour {

	private Transform startClimbPoint;
	public Transform endClimbPoint;
	public Transform endMovePoint;

	private bool startClimb;
	private bool endClimb;

	//public float speed = 0.5f;
	public float apexPushForce = 1f;

	private bool climbs = false;
	private bool postClimb = false;

	private bool clicked = false;

	public GameObject objectplayer;
	//private float playerGravity;

	private bool finalJourneyDirectionIsRight;

    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength1;
    private float journeyLength2;

	//private float startTime;
	//private float journey1Length;
	//private float journey2Length;

	// Use this for initialization
	void Start () {
		//journey1Length = Vector3.Distance(startClimbPoint.position, endClimbPoint.position);
		//journey1Length = Vector3.Distance(endClimbPoint.position, endMovePoint.position);
		//finalJourneyDirectionIsRight = (endClimbPoint.position.x < endMovePoint.position.x)?(true):(false);
	}

	// Update is called once per frame
	void Update () {

        float distCovered = (Time.time - startTime) * speed;
		//Debug.Log(startClimb);
        //Debug.Log(endClimb);
		if(startClimb){
            float fracJourney = distCovered / journeyLength1;
            objectplayer.transform.position = Vector2.Lerp(startClimbPoint.position, endClimbPoint.position, fracJourney);
			//Debug.Log(objectplayer.transform.position);
            //Debug.Log(fracJourney);
            //Debug.Log(endClimbPoint.position);
			//Debug.Log(objectplayer.transform.position == endClimbPoint.position);
			if(objectplayer.transform.position == endClimbPoint.position){
				endClimb = true;
                startTime = Time.time;
				startClimb = false;
			}
		}else if(endClimb){
            float fracJourney = distCovered / journeyLength2;
            objectplayer.transform.position = Vector2.Lerp(endClimbPoint.position, endMovePoint.position, fracJourney);
            if (objectplayer.transform.position == endMovePoint.position){
                endClimb = true;
                startTime = Time.time;
                objectplayer.gameObject.GetComponent<PlayerCharacterController>().climbingwall = null;
				objectplayer = null;

            }
        }else{
			//Debug.Log("not climbing");
		}
		//if(objectplayer == null)
		//{
		//	return;
		//}
		//Debug.Log("Update: objectplayer not null");
		//if(objectplayer.GetComponent<playermovement>().climbingMode)
		//{
			//Debug.Log("Update: coords check: "+objectplayer.transform.position.y+", "+endClimbPoint.position.y);
		//	if(objectplayer.transform.position.y >= endClimbPoint.position.y &&
		//	   objectplayer.GetComponent<playermovement>().climbingMid)
		//	{
				//Debug.Log("And I at least get to here...");
		//		objectplayer.GetComponent<Rigidbody2D>().AddForce(
		//				new Vector2(
		//						(finalJourneyDirectionIsRight)?(apexPushForce):(0f-apexPushForce),
		//						0f));
		//	}
		//}
		/*if(climb)
		{
			if(Vector3.Distance(objectplayer.transform.position,endClimbPoint.position) < 0.01f)
			{
				climb = false;
				postClimb = true;
			}
			  Vector3 climbVectorE = new Vector3(objectplayer.transform.position.x,endClimbPoint.position.y,objectplayer.transform.position.z);
				//objectplayer.transform.position = Vector3.Lerp(startClimbPoint.position,climbVectorE,speed * Time.deltaTime);
				objectplayer.transform.position = Vector3.Lerp(objectplayer.transform.position,climbVectorE,speed * Time.deltaTime);
					Debug.LogError("CLIMB:PY="+objectplayer.transform.position.y+", FY="+endClimbPoint.position.y);
					if(Vector3.Distance(objectplayer.transform.position,endClimbPoint.position) < 0.5f)
					{
						climb = false;
						postClimb = true;
					}
		}
		if(postClimb)
		{
			Debug.LogError("POSTCLIMB:PY="+objectplayer.transform.position.y+", FY="+endClimbPoint.position.y);
			objectplayer.transform.position = Vector3.Lerp(objectplayer.transform.position,endMovePoint.position,speed * Time.deltaTime);
			//if(objectplayer.transform.position.x == endMovePoint.position.x)
			//{

			//}
		}*/
	}

	public void climb(Transform position){
		Debug.Log("Hello");
		startTime = Time.time;
        startClimbPoint = position;
		journeyLength1 = Vector2.Distance(startClimbPoint.position, endClimbPoint.position);
        journeyLength2 = Vector2.Distance(endClimbPoint.position, endMovePoint.position);
		startClimb = true;
	}
    void OnMouseDown()
    {
			//clicked = true;
			/*
				if(objectplayer.GetComponent<playermovement>().item == 3){
            climb = true;
						//startTime = Time.time;
						objectplayer.transform.position = startClimbPoint.position;
						playerGravity = objectplayer.GetComponent<Rigidbody2D>().gravityScale;
						objectplayer.GetComponent<Rigidbody2D>().gravityScale = 0f;
				}*/
    }

    void OnMouseExit()
    {
        //clicked = false;
    }

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("Enter");
        //Debug.Log(other.gameObject.name);
		if(other.gameObject.tag == "Player"){
            //Debug.Log(other.gameObject.name);
            //Debug.Log(other.gameObject.GetComponent<playermovement>().item == 3);
            //climb = true;
			//objectplayer = other.gameObject;
            //Debug.Log(other.gameObject);
			//Debug.Log(other.gameObject.GetComponent<PlayerCharacterController>());
            //other.gameObject.GetComponent<PlayerCharacterController>().climbingwall = this;
            //objectplayer = other.gameObject;
			//objectplayer.GetComponent<PlayerCharacterController>().climb();
						//objectplayer.GetComponent<playermovement>().climbingSpeed = speed;
						//playerGravity = objectplayer.GetComponent<Rigidbody2D>().gravityScale;
						//objectplayer.GetComponent<Rigidbody2D>().gravityScale = 0f;
            //if (other.gameObject.GetComponent<playermovement>().item == 3 && clicked){
			//	Debug.Log("Climb");
            //   climb = true;
            //
			//}
		}
	}
    void OnTriggerExit2D(Collider2D other){
        //Debug.Log("exit");
        //Debug.Log(other.gameObject.name);
        /*if(other.gameObject == null || objectplayer == null)
        {
            return;
        }*/
        //if (other.gameObject.name == "Rogue_01")
        //{
        //			  other.gameObject.GetComponent<playermovement>().climbingMode = false;
        //				//objectplayer.GetComponent<Rigidbody2D>().gravityScale = playerGravity;
        //				objectplayer = null;
        //    climb = false;
        //				postClimb = false;
        //}
        //if (other.gameObject.tag == "Player"){
            //Debug.Log("Something");
            //endClimb = true;
			//startTime = Time.time;
            //startClimb = false;
		//}
    }
}
