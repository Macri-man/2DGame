using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool isPaused = false;

	public GameObject pauseUI;
	
	// Update is called once per frame

	void Awake() {
		if(pauseUI == null){
			Debug.LogError("Need PauseMenu");
		}
		pauseUI.SetActive(false);
        //Resume();
	}

	void Start() {
        Resume();
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("ESCAPE");
			if(isPaused){
				Resume();
			}else{
				Pause();
			}
		}
	}

	public void Resume(){
        Debug.Log("RESUME");
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
	}

	void Pause(){
		Debug.Log("PAUSE");
        pauseUI.SetActive(true);
		Time.timeScale = 0;
		isPaused = true;
	}

	public void loadMenu(){
		SceneManager.LoadScene("Menu");
	}

	public void quitGame(){
		Debug.Log("QUITGAME");
		Application.Quit();

	}
}
