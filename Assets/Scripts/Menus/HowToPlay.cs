using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour {


	public void PlayGame(){
		SceneManager.LoadScene("Level1");
	}
	public void BackToMenu(){
		SceneManager.LoadScene("Menu");
	}
	public void QuitGame(){
		Debug.Log("QUITING");
		Application.Quit();
	}

}
