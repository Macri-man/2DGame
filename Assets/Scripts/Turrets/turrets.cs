using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrets : MonoBehaviour {

    public SoundTrigger FireSound;
    public SoundTrigger SwitchedOffSound;
    public SoundTrigger GettingHitSound;

    private GameObject target;

	public Transform spawnBullets;
    public Transform BarrelTurret;
	public GameObject projectile;

    private float timeCount = 0.0f;

	public float rateOfFire = 1f;

	public float speedTurn = 2;
	private bool enterZone;

	public ParticleSystem flameThrower;

    Vector3 direct;
    float angle;
    float angle2;
	float rotateAmount;
    float angleOfTurret = 0;
    Quaternion rotate;

	bool fire = false;

    float timeStamp;


	// Use this for initialization
	void Start () {
		
		//Debug.Log(this.gameObject.name);
	}
	
	// Update is called once per frame
	void Update(){
		if(enterZone){
        	direct = target.transform.position - this.BarrelTurret.transform.position;
			direct.Normalize();
			rotateAmount = Vector3.Cross(direct,this.BarrelTurret.transform.up).z;
        	angle = Mathf.Atan2(direct.y,direct.x) * Mathf.Rad2Deg;
            angle2 = AngleBetweenVector2(this.BarrelTurret.transform.up, direct);
            Vector2 vec1Rotated90 = new Vector2(-this.BarrelTurret.transform.up.y, this.BarrelTurret.transform.up.x);
            float sign = (Vector2.Dot(vec1Rotated90, direct) < 0) ? -1.0f : 1.0f;
            Debug.DrawLine((Vector2)this.BarrelTurret.transform.position, (Vector2)target.transform.position, Color.black, 200f);
            Debug.DrawRay((Vector2)this.BarrelTurret.transform.position, direct, Color.red, 200f);
            Debug.DrawRay((Vector2)this.BarrelTurret.transform.position, this.BarrelTurret.transform.up, Color.blue, 200f);
            //Debug.Log(rotateAmount);
            //Debug.Log(this.BarrelTurret.transform.rotation.eulerAngles);
            rotate = Quaternion.AngleAxis(angle,Vector3.forward);
            //Debug.Log(rotate.eulerAngles);
            rotate = Quaternion.AngleAxis(angle2, Vector3.forward);
            //Debug.Log(rotate.eulerAngles);
            //Debug.Log(Quaternion.Euler(0,0,this.BarrelTurret.transform.rotation.z + -rotateAmount * speedTurn * Time.deltaTime).eulerAngles);

            //this.BarrelTurret.transform.rotation = Quaternion.Euler(0, 0, this.BarrelTurret.transform.rotation.z + -rotateAmount * speedTurn * Time.deltaTime);
            this.BarrelTurret.transform.RotateAround(this.BarrelTurret.transform.position, new Vector3(0f, 0f, 1f), -rotateAmount * speedTurn * Time.deltaTime);
            //Debug.Log(this.BarrelTurret.transform.rotation.eulerAngles);
            //this.BarrelTurret.transform.rotation = Quaternion.Slerp(transform.rotation, rotate, -rotateAmount * speedTurn * Time.deltaTime);
            //Debug.Log(this.BarrelTurret.transform.rotation.eulerAngles);
            
            //this.BarrelTurret.transform.RotateAround(this.BarrelTurret.transform.position,new Vector3(0,0,1), -rotateAmount * speedTurn * Time.deltaTime);
            //this.BarrelTurret.transform.rotation = Quaternion.Euler(0, 0, this.BarrelTurret.transform.rotation.z + sign * speedTurn * Time.deltaTime);
            //this.transform.rotation = Quaternion.Euler(0,0,Mathf.Clamp(this.transform.rotation.z,0,180)); 
            //withinBounds(230,310);

            //Debug.Log(sign * speedTurn * Time.deltaTime);

            //angleOfTurret += sign * speedTurn * Time.deltaTime;
            //Debug.Log(angleOfTurret);

            //this.BarrelTurret.transform.rotation = Quaternion.Euler(0,0,angleOfTurret);
            if(withinThreshold(2) && (Time.time > timeStamp)){ 
                //FireSound.PlaySound();
                //StartCoroutine("Shoot");
                timeStamp += Time.time;
				if(flameThrower == null){
                    GameObject bullets = (GameObject)Instantiate(projectile, spawnBullets.position, spawnBullets.rotation);
                    bullets.GetComponent<Projectile>().setLocalScale();
                    bullets.GetComponent<Projectile>().speed = 1;
				}else{
					flameThrower.Play();
				}
			}else{
				if(flameThrower != null){
                    flameThrower.Stop();
				}
			}
		}
    }

    void withinBounds(float boundLeft, float boundRight){
        //return withinThreshold(boundLeft) && withinThreshold(boundrRght);
        //return (transform.rotation.eulerAngles.z >= boundLeft) && (transform.rotation.eulerAngles.z <= boundRight);
        if((transform.rotation.eulerAngles.z >= boundLeft) && (transform.rotation.eulerAngles.z <= boundRight)){
            if(Mathf.Abs(transform.rotation.eulerAngles.z-boundLeft) >= Mathf.Abs(transform.rotation.eulerAngles.z - boundRight)) {
                transform.rotation = Quaternion.Euler(0, 0, boundRight);
            }else{
                transform.rotation = Quaternion.Euler(0, 0, boundLeft);
            }
        }
        /* 
        if (boundLeft - transform.rotation.eulerAngles.z <= 0){
            transform.rotation = Quaternion.Euler(0, 0, boundLeft);
        }else if (transform.rotation.eulerAngles.z <= boundRight){
            transform.rotation = Quaternion.Euler(0, 0, boundRight);
        }else{

        }
        */
    }


    bool withinThreshold(float threshold){
        return (transform.rotation.eulerAngles.z <= (rotate.eulerAngles.z + threshold)) && (transform.rotation.eulerAngles.z >= (rotate.eulerAngles.z - threshold));
    }

	void OnTriggerEnter2D(Collider2D other) {
		switch(other.gameObject.tag){
			case "Player":
				Debug.Log("Entered");
				enterZone = true;
				target = other.gameObject;
			break;
			default:
			break;
		}
		
	}
    float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 vec1Rotated90 = new Vector2(-vec1.y, vec1.x);
        float sign = (Vector2.Dot(vec1Rotated90, vec2) < 0) ? -1.0f : 1.0f;
        return Vector2.Angle(vec1, vec2) * sign;
    }

    void OnTriggerExit2D(Collider2D other){
        switch (other.gameObject.tag){
            case "Player":
                enterZone = false;
				target = null;
                break;
            default:
                break;
        }
    }
}
