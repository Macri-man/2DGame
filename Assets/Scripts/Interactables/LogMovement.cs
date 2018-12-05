using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMovement : MonoBehaviour {

	public Transform endPoint;
	public float rotateSpeed = 1f;
    float angle2 = 0;

    public SoundTrigger triggers;
    private bool clicked = false;

    private bool moveLog = false;

    Quaternion end = Quaternion.identity;

    Quaternion rotate;

	void Start() {
        Vector2 direct = (Vector2)endPoint.position - (Vector2)this.transform.position;
		direct.Normalize();
        angle2 = AngleBetweenVector2(transform.up, direct);
        //Debug.DrawRay((Vector2)this.transform.position, direct, Color.blue, 200f);
        //Debug.DrawRay((Vector2)this.transform.position, this.transform.right, Color.red, 200f);
        //Debug.DrawRay((Vector2)this.transform.position, this.transform.up, Color.cyan, 200f);
        //Debug.Log(AngleBetweenVector2(transform.up, direct));
        end = Quaternion.Euler(0,0,endPoint.transform.rotation.z + angle2);
	}

    void OnMouseDown(){
        Debug.Log("Mouse Down");
        clicked = true;
    }
	void OnMouseUp(){
        Debug.Log("Mouse up");
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
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, end, Time.deltaTime * rotateSpeed);
        }
	}

    void OnTriggerStay2D(Collider2D other){
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Player"){
            //Debug.Log(clicked);
            //Debug.Log(other.gameObject.GetComponent<playermovement>().item == Weapons.Hammer);
			if(other.gameObject.GetComponent<playermovement>().item == Weapons.Hammer && clicked){
            	triggers.PlaySound();
				moveLog = true;
			}
        }
    }
}
