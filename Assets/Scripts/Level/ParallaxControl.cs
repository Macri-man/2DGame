using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxControl : MonoBehaviour {

  public Transform[] scrollTargets;
	private float[] parallaxScales;
	public float scrollSmoothing = 1f; // How smooth the parallax is going to be. Make sure to set this above 0
	private Transform mainCameraTransform; // reference to the main cameras transform
	private Vector3 previousCameraPos; // the position of the camera in the previous frame

	void Awake ()
	{
		// set up camera the reference
		mainCameraTransform = Camera.main.transform;
	}
	// Use this for initialization
	void Start ()
	{
		// The previous frame had the current frame's camera position
		previousCameraPos = mainCameraTransform.position;  // asigning coresponding parallaxScales
		parallaxScales = new float[scrollTargets.Length];
		for (int i = 0; i < scrollTargets.Length; i++)
		{
			parallaxScales[i] = i*-10;//scrollTargets[i].position.z*-1;
		}
	}
	// Update is called once per frame
	void Update ()
	{
		// for each background
		for (int i = 0; i < scrollTargets.Length; i++)
		{
			// the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
			float parallax = (previousCameraPos.x - mainCameraTransform.position.x) * parallaxScales[i];
			// set a target x position which is the current position plus the parallax
			float backgroundTargetPosX = scrollTargets[i].position.x + parallax;
			// create a target position which is the background's current position with its target x position
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, scrollTargets[i].position.y, scrollTargets[i].position.z);
			// fade between current position and the target position using lerp
			scrollTargets[i].position = Vector3.Lerp (scrollTargets[i].position, backgroundTargetPos, scrollSmoothing * Time.deltaTime);
		}
		// set the previousCamPos to the camera's position at the end of the frame
		previousCameraPos = mainCameraTransform.position;
	}
}﻿
