using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour {

	public Transform startClimbPoint;
	public Transform endClimbPoint;
	public Transform endMovePoint;

	public float speed = 0.5f;


	private bool climb = false;
	private bool postClimb = false;

	private bool clicked = false;

	private GameObject objectplayer;
	private float playerGravity;

	//private float startTime;
	//private float journey1Length;
	//private float journey2Length;

	// Use this for initialization
	void Start () {
		//journey1Length = Vector3.Distance(startClimbPoint.position, endClimbPoint.position);
		//journey1Length = Vector3.Distance(endClimbPoint.position, endMovePoint.position);
	}

	// Update is called once per frame
	void Update () {
		if(objectplayer == null)
		{
			return;
		}
		if(climb)
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
		}
	}
    void OnMouseDown()
    {
        clicked = true;
				if(objectplayer.GetComponent<playermovement>().item == 3){
            climb = true;
						//startTime = Time.time;
						objectplayer.transform.position = startClimbPoint.position;
						playerGravity = objectplayer.GetComponent<Rigidbody2D>().gravityScale;
						objectplayer.GetComponent<Rigidbody2D>().gravityScale = 0f;
				}
    }

    void OnMouseExit()
    {
        clicked = false;
    }

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("Enter");
        //Debug.Log(other.gameObject.name);
		if(other.gameObject.name == "Rogue_01"){
            //Debug.Log(other.gameObject.name);
            //Debug.Log(other.gameObject.GetComponent<playermovement>().item == 3);
            //climb = true;
            objectplayer = other.gameObject;
            //if (other.gameObject.GetComponent<playermovement>().item == 3 && clicked){
			//	Debug.Log("Climb");
            //   climb = true;
            //
			//}
		}
	}
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Rogue_01")
        {
            climb = false;
						postClimb = false;
						objectplayer.GetComponent<Rigidbody2D>().gravityScale = playerGravity;
						objectplayer = null;
        }
    }
}
