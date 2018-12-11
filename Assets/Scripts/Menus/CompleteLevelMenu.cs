using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevelMenu : MonoBehaviour {

	private GameObject completeLevelUI;
	
	// Update is called once per frame

	void Awake() {
		
        //Resume();
	}

	void Start() {

        completeLevelUI = GameObject.FindGameObjectWithTag("CompleteLevelMenu");
        if (completeLevelUI == null){
            Debug.LogError("Need CompleteLevelMenu");
        }
        completeLevelUI.SetActive(false);
	}

	void Update() {

	}

	public void Continue(){
		if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
		}
	}

	public void loadMenu(){
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}

	public void quitGame(){
		Debug.Log("QUITGAME");
		Application.Quit();
	}

}
