using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switches : MonoBehaviour {

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    public BoolEvent OnInputEvent;
	public GameObject Orb;
    public GameObject Lever;
	public Transform endPoint;

	bool switchesOn = false;
	public float interval;
    float timeStamp;

	Transform startposition;

	// Use this for initialization
	void Start () {
        startposition = Lever.transform;
	}
	
	// Update is called once per frame
	void Update () {

		if(switchesOn){
            Lever.transform.rotation = Quaternion.Lerp(Lever.transform.rotation, Quaternion.Euler(0, 0, Lever.transform.rotation.z + 45), Time.time / interval);
        }else{
            Lever.transform.rotation = Quaternion.Lerp(Lever.transform.rotation, Quaternion.Euler(0, 0, startposition.rotation.z), Time.time / interval);
		}

		if(switchesOn && ((Time.time - timeStamp) > interval)){
            timeStamp += Time.time;
            Orb.GetComponent<SpriteRenderer>().color = Color.white;
            switchesOn = !switchesOn;
            OnInputEvent.Invoke(switchesOn);
		}
	}

	void OnMouseDown() {
		if(OnInputEvent != null){
            timeStamp = Time.time;
            switchesOn = !switchesOn;
            OnInputEvent.Invoke(switchesOn);
			Orb.GetComponent<SpriteRenderer>().color = Color.black;
		}else{
			Debug.LogWarning("No Turret On Switch");
		}
		
	}
}
