using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitSpikes : MonoBehaviour {

	public SoundTrigger HitSound;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		switch(other.gameObject.tag)
		{
			case "Player":
				other.gameObject.GetComponent<playermovement>().death();
				if(null != HitSound)
				{
					HitSound.PlaySound();
				}
			break;
			default:
								//HitSound.PlaySound();
								//Destroy(this.gameObject);
			break;

		}
	}
}
