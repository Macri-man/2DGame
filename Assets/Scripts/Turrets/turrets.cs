using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrets : MonoBehaviour {

    public SoundTrigger FireSound;
    public SoundTrigger SwitchedOffSound;
    public SoundTrigger GettingHitSound;

    public GameObject target;

	public Transform spawnBullets;
	public Projectile projectile;

    private float timeCount = 0.0f;

	public float rateOfFire = 1f;

	public float speed = 2;
	private bool enterZone;

	public ParticleSystem flameThrower;

    Vector3 direct;
    float angle;
    float angle2;
    Quaternion rotate;

	bool fire = false;

    float timeStamp;


	// Use this for initialization
	void Start () {
		
		//Debug.Log(this.gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
		if(enterZone){
        	direct = target.transform.position - this.transform.position; 
        	angle = Mathf.Atan2(direct.y,direct.x) * Mathf.Rad2Deg; 
            angle2 = AngleBetweenVector2(transform.up, direct); 
			//Debug.Log(angle2);
            Debug.DrawLine((Vector2)this.transform.position, (Vector2)target.transform.position, Color.black, 200f);
            Debug.DrawRay((Vector2)this.transform.position, direct, Color.red, 200f);
            Debug.DrawRay((Vector2)this.transform.position, transform.up, Color.blue, 200f);
			rotate = Quaternion.AngleAxis(angle,Vector3.forward); 
			this.transform.rotation = Quaternion.Slerp(transform.rotation,rotate,speed*Time.deltaTime);
			if(withinThreshold(5f) && (Time.time > timeStamp)){
                //FireSound.PlaySound();
                //StartCoroutine("Shoot");
				
                timeStamp += Time.time;
				if(flameThrower == null){ 	
                    Instantiate(projectile, spawnBullets.position, spawnBullets.rotation); 
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
