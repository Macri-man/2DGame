using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


	public void PlayGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1,LoadSceneMode.Single);
	}
	public void HowToPlay(){
		SceneManager.LoadScene("HowToPlay",LoadSceneMode.Single);
	}

	public void QuitGame(){
		Debug.Log("QUITING");
		Application.Quit();
	}

}
