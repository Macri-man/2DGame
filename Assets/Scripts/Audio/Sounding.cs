using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


[CreateAssetMenu(fileName = "New Sound", menuName = "2DGame/Sounds")]
public class Sounding : ScriptableObject {

	public new string name;
	public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = .75f;
    [Range(-3f, 3f)]
    public float pitch = 1f;
    public bool loop = false;
    [HideInInspector]
    public AudioSource source;

}
