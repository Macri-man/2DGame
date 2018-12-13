using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	private static bool isPaused = false;

	private GameObject pauseUI;
	
	// Update is called once per frame

	void Awake() {

	}

	void Start() {
        pauseUI = GameObject.FindGameObjectWithTag("PauseMenu");
        if (pauseUI == null){
            Debug.LogError("Need PauseMenu");
        }
        pauseUI.SetActive(false);
        //Resume();
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
            //Debug.Log("ESCAPE");
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

	public void howToPlay(){
        	Debug.Log("howtoplay");
        	Time.timeScale = 0;
        	SceneManager.LoadSceneAsync("HowToPlay",LoadSceneMode.Additive);
        	pauseUI.SetActive(false);
	}

	void Pause(){
		Debug.Log("PAUSE");
        	pauseUI.SetActive(true);
		Time.timeScale = 0;
		isPaused = true;
	}

	public void loadMenu(){
        Debug.Log("load");
        SceneManager.LoadScene("Menu",LoadSceneMode.Single);
	}

	public void quitGame(){
		Debug.Log("QUITGAME");
		Application.Quit();

	}
}
