using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevelMenu : MonoBehaviour {

	public GameObject completeLevelUI;
	
	// Update is called once per frame

	void Awake() {
		
        //Resume();
	}

	void Start() {
        if (completeLevelUI == null){
            Debug.LogError("Need CompleteLevelMenu");
        }
        completeLevelUI.SetActive(false);
	}

	void Update() {

	}

	public void Continue(){
		if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings){
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}

	public void loadMenu(){
		SceneManager.LoadSceneAsync("Menu");
	}

	public void quitGame(){
		Debug.Log("QUITGAME");
		Application.Quit();
	}

}
