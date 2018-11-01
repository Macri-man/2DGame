using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrets : MonoBehaviour {

	public GameObject target;

    private float timeCount = 0.0f;

	public float speed = 2;

	// Use this for initialization
	void Start () {
		if(target == null){
			Debug.Log("settarget");
		}
		Debug.Log(this.gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 direct = target.transform.position - this.transform.position;

		
        Quaternion lookAtRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        lookAtRotation.SetFromToRotation(this.transform.position,target.transform.position);
		Debug.Log(lookAtRotation.eulerAngles);
        Debug.Log(this.transform.rotation.eulerAngles);

		float angle = Mathf.Atan2(direct.y,direct.x) * Mathf.Rad2Deg;

		Quaternion rotate = Quaternion.AngleAxis(angle,Vector3.forward); 

		this.transform.rotation = Quaternion.Slerp(transform.rotation,rotate,speed*Time.deltaTime);

		if(transform.rotation == rotate){
            Debug.Log("Fire");
		}
/* 
        if (transform.rotation != lookAtRotation)
        {
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, lookAtRotation, Time.deltaTime * speed);
        }else{
            Debug.Log("Fire");
        }
		*/
//transform.LookAt(player.transform.position,Vector3.up);
    }
}
