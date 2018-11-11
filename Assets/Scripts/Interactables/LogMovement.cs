using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMovement : MonoBehaviour {

	public Transform startPoint;
	public Transform endPoint;
	public float rotateSpeed = 1f;

    float rotateAmount = 0;
    float angle = 0;
    float angle2 = 0;

    public SoundTrigger triggers;
    private bool clicked = false;

	private bool entered = false;
    private bool moveLog = false;

    [Range(-1,1)]
    public int direction = 0;



    Quaternion rotate;

	void Start() {
        Vector2 direct = (Vector2)endPoint.position - (Vector2)startPoint.position;
		direct.Normalize();
        rotateAmount = Vector3.Cross(direct,transform.up).z;
        angle = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
        angle2 = AngleBetweenVector2(transform.up, direct);
        //Debug.Log(rotateSpeed);
        //Debug.Log(rotateAmount*rotateSpeed);
        //Debug.Log(rotateAmount);
        //Debug.Log(angle* rotateSpeed);
        //Debug.Log(angle);
        rotate = Quaternion.AngleAxis(rotateAmount, new Vector3(0f, 0f, 1f));
        //Debug.Log(rotate.eulerAngles);
        rotate = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
        //Debug.Log(rotate.eulerAngles);
        rotate = Quaternion.AngleAxis(angle2, new Vector3(0f, 0f, 1f));
        //Debug.Log(rotate.eulerAngles);
        Debug.DrawLine((Vector2)startPoint.position, (Vector2)endPoint.position, Color.black, 200f);
        Debug.DrawRay((Vector2)startPoint.position, direct, Color.red, 200f);
        Debug.DrawRay((Vector2)startPoint.position, transform.up, Color.blue, 200f);
        //Debug.Log(AngleBetweenVector2(transform.up, direct));
        //Debug.Log(AngleBetweenVector21(transform.up, direct));
        //Debug.Log(Vector2.Angle(transform.up,direct));
	}

    void OnMouseDown(){
        clicked = true;
    }
	void OnMouseExit(){
        clicked = false;
	}
    private float AngleBetweenVector21(Vector2 vec1, Vector2 vec2)
    {
        Vector2 difference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, difference) * sign;
    }

    float AngleBetweenVector2(Vector2 vec1, Vector2 vec2){
        Vector2 vec1Rotated90 = new Vector2(-vec1.y, vec1.x);
        float sign = (Vector2.Dot(vec1Rotated90, vec2) < 0) ? -1.0f : 1.0f;
        return Vector2.Angle(vec1, vec2) * sign;
    }
	void Update() {
		if(moveLog){
            transform.RotateAround(startPoint.position, new Vector3(0f, 0f, 1f), -rotateSpeed * Time.deltaTime);
            //Debug.Log(transform.rotation.eulerAngles);
            //Debug.Log(rotate.eulerAngles);
            //Debug.Log(transform.rotation.eulerAngles.z <= (rotate.eulerAngles.z + 5) && transform.rotation.eulerAngles.z >= (rotate.eulerAngles.z + -5));
            //Debug.Log(transform.rotation.eulerAngles.z <= (rotate.eulerAngles.z + 5));
            //Debug.Log(transform.rotation.eulerAngles.z >= (rotate.eulerAngles.z - 5));
			if(withinThreshold(5f)){
				moveLog = false;
			}
        }
	}

    bool withinThreshold(float threshold){
        return (transform.rotation.eulerAngles.z <= (rotate.eulerAngles.z + threshold)) && (transform.rotation.eulerAngles.z >= (rotate.eulerAngles.z - threshold));
    }

    void OnTriggerStay2D(Collider2D other){
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Player"){
            Debug.Log(clicked);
			if(other.gameObject.GetComponent<playermovement>().item == 1 && clicked){
            	triggers.PlaySound();
				moveLog = true;
			}
        }
    }
}
