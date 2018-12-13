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
	//public float apexPushForce = 1f;

	private bool climbs = false;
	private bool postClimb = false;

	private bool clicked = false;

	public GameObject objectplayer;
	//private float playerGravity;

	private bool finalJourneyDirectionIsRight;

    public float speed;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength1;
    private float journeyLength2;
    float distCovered;
    float fracJourney;

    //private float startTime;
    //private float journey1Length;
    //private float journey2Length;

    // Use this for initialization
    void Start () {
        //journey1Length = Vector3.Distance(startClimbPoint.position, endClimbPoint.position);
        //journey1Length = Vector3.Distance(endClimbPoint.position, endMovePoint.position);
        //finalJourneyDirectionIsRight = (endClimbPoint.position.x < endMovePoint.position.x)?(true):(false);
        //distCovered = 0;
	}

	// Update is called once per frame
	void Update () {

        //distCovered = (Time.time - startTime) * speed * Time.deltaTime;
				distCovered += speed * Time.deltaTime;
				//Debug.Log(distCovered);
		if(startClimb){
            fracJourney = (1 / journeyLength1) * distCovered;
						//Debug.Log(fracJourney);
            objectplayer.transform.position = Vector2.Lerp(startClimbPoint.position, endClimbPoint.position, fracJourney);
						//startClimbPoint.position
			//Debug.Log(objectplayer.transform.position);
            //Debug.Log(fracJourney);
            //Debug.Log(endClimbPoint.position);
			//Debug.Log((objectplayer.transform.position - endClimbPoint.position).magnitude);
			//if(fracJourney > 1){
			if((objectplayer.transform.position - endClimbPoint.position).magnitude <= 0.4){
				endClimb = true;
                startTime = Time.time;
				distCovered = 0;
				startClimb = false;
			}
		}else if(endClimb){
            fracJourney = (1 / journeyLength2) * distCovered;
            objectplayer.transform.position = Vector2.Lerp(objectplayer.transform.position, endMovePoint.position, fracJourney);
						//Debug.Log((objectplayer.transform.position - endMovePoint.position).magnitude);
            if ((objectplayer.transform.position - endMovePoint.position).magnitude <= 0.4){
                endClimb = false;
                startClimb = false;
                journeyLength1 = journeyLength2 = 0;
                objectplayer.gameObject.GetComponent<PlayerCharacterController>().endClimb();
                objectplayer.gameObject.GetComponent<PlayerCharacterController>().climbingwall = null;
				objectplayer = null;
            }
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

	public void killClimbValues()
	{
		startClimb = false;
		endClimb = false;
		objectplayer = null;
		journeyLength1 = journeyLength2 = 0;
	}

	public void climb(Transform position){
		//Debug.Log("Hello");
		startTime = Time.time;
        startClimbPoint = position;
		journeyLength1 = Vector2.Distance(startClimbPoint.position, endClimbPoint.position);
        journeyLength2 = Vector2.Distance(endClimbPoint.position, endMovePoint.position);
		startClimb = true;
        distCovered = 0;
		//Debug.Log(startClimb);
        //Debug.Log(journeyLength1);
        //Debug.Log(journeyLength2);
	}
   
}
