using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

	Vector3 offset;
	public float smoothing = 0.125f;

  	public Camera mainCamera;
	public GameObject playerCharacter;
	// Use this for initialization
	void Awake () {
    //now check that there is a mainCamera set
		if(mainCamera == null)
		{
			Debug.LogError("CameraBehaviour: No mainCamera instance set");
		}
        if (playerCharacter == null)
        {
            Debug.LogError("CameraBehaviour: No mainCamera instance set");
        }

	}

	void Update () {
		/*Vector3 desiredPosition = playerCharacter.transform.position + offset;
		Vector3 smoothPosition = Vector3.Lerp(transform.position,
										new Vector3(desiredPosition.x,desiredPosition.y,transform.position.z),
										(smoothing*Time.deltaTime));
			transform.position = smoothPosition;*/
			Vector3 desiredPosition = playerCharacter.transform.position + offset;
			transform.position = new Vector3(desiredPosition.x,desiredPosition.y,transform.position.z);

	}
}
