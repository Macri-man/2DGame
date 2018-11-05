using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public LevelGenerator levelScript;
	//public StageManager stageScript;

	private int level = 1;
	// Use this for initialization
	void Awake () {
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
		//stageScript = GetComponent<StageManager>();
		levelScript = GetComponent<LevelGenerator>();
		InitGame();

	}

	void InitGame()
	{
		//stageScript.SetupScene(level);
		//levelScript.GenerateLevel();
	}

	// Update is called once per frame
	void Update () {

	}
}
