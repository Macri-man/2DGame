using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Sound Trigger", menuName = "2DGame/SoundTriggers")]
public class SoundTrigger : ScriptableObject {

	public string nameOfSound;
	private AudioManager manager;

	public void PlaySound(){

        manager = FindObjectOfType<AudioManager>();
		if(manager == null){
			Debug.LogError("AudiManager not Present");
			return;
		}
		manager.Play(nameOfSound);
	}
}
