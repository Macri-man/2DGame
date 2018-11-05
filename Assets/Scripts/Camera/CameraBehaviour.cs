using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

	public static CameraBehaviour instance = null;
  public Camera mainCamera;
	public GameObject playerCharacter;
	public GameObject[] tileMaps;

	private Transform cameraTransform;
	private float cameraWidth;
	private float cameraHeight;
	private Transform playerTransform;
	// Use this for initialization
	void Awake () {
		//first check to ensure that this is going
		//to be the only CameraBehaviour object:
		//if one already exists, destroy this
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy(gameObject);
		}
    //now check that there is a mainCamera set
		if(mainCamera == null)
		{
			Debug.LogError("CameraBehaviour: No mainCamera instance set");
		}
		else
		{
			cameraTransform = mainCamera.transform;
			cameraWidth = mainCamera.rect.width;
			cameraHeight = mainCamera.rect.height;
			Debug.LogError("CameraBehaviour: cW="+cameraWidth+",cH="+cameraHeight);
			//we have a mainCamera, now check for playerCharacter
			if(playerCharacter == null)
			{
				Debug.LogError("CameraBehaviour: No mainCamera instance set");
			}
			else
			{
				playerTransform = playerCharacter.transform;
				//we can now set the camera to follow the playerCharacter
				//cameraTransform.position = playerTransform.position+new Vector3((cameraWidth << 1),(cameraHeight << 1),0f);

			}
		}


	}

	// Update is called once per frame
	void Update () {
		if(cameraTransform.position.x < (playerTransform.position.x-(cameraWidth / 2)) )
		{
			cameraTransform.Translate(new Vector3(0.01f,0f,0f));
		}
		else if(cameraTransform.position.x > (playerTransform.position.x-(cameraWidth / 2)) )
		{
			cameraTransform.Translate(new Vector3(-0.01f,0f,0f));
		}
		if(cameraTransform.position.y < (playerTransform.position.y-(cameraHeight / 2)) )
		{
			cameraTransform.Translate(new Vector3(0f,0.01f,0f));
		}
		else if(cameraTransform.position.y > (playerTransform.position.y-(cameraHeight / 2)) )
		{
			cameraTransform.Translate(new Vector3(0f,-0.01f,0f));
		}

		//mainCamera.Render();

	}
}
