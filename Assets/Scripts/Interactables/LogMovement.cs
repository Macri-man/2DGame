using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMovement : MonoBehaviour {

	public Transform startPoint;
	public Transform endPoint;
	public float rotateSpeed = 10f;

    public SoundTrigger triggers;
    private bool clicked = false;

	private bool entered = false;
    private bool moveLog = false;

    Quaternion rotate;

	void Start() {
        Vector3 direct = endPoint.position - startPoint.position;
		direct.Normalize();
        float angle = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
        rotate = Quaternion.AngleAxis(angle, -Vector3.forward);
	}

    void OnMouseDown(){
        clicked = true;
    }

	void OnMouseExit(){
        clicked = false;
	}

	void FixedUpdate() {
		if(moveLog){
            transform.RotateAround(startPoint.position, new Vector3(0f, 0f, -1f), rotateSpeed * Time.deltaTime);
            Debug.Log(transform.rotation != rotate);
            Debug.Log(transform.rotation.eulerAngles);
            Debug.Log(rotate.eulerAngles);
			if(transform.rotation == rotate){
				moveLog = false;
			}
        //this.transform.rotation = Quaternion.Slerp(transform.rotation, rotate, rotateSpeed * Time.deltaTime);
        }
	}

    void OnTriggerStay2D(Collider2D other){

       // Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Rogue_01"){
            entered = true;
            //Debug.Log(other.gameObject.name == "Rogue_01");
            //Debug.Log(other.gameObject.GetComponent<playermovement>().item == 1);
            //Debug.Log(clicked);
			if(other.gameObject.GetComponent<playermovement>().item == 1 && clicked){
            	triggers.PlaySound();
				moveLog = true;
				clicked = false;
			}
        }
    }

    public IEnumerator Rotatelog(Quaternion rotate){
        while (transform.rotation != rotate){
			Debug.Log(transform.rotation != rotate);
            Debug.Log(transform.rotation.eulerAngles);
            Debug.Log(rotate.eulerAngles);
            //this.transform.rotation = Quaternion.Slerp(transform.rotation, rotate, rotateSpeed * Time.deltaTime);
            transform.RotateAround(startPoint.position, new Vector3(0f, 0f, -1f), rotateSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
