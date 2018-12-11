using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour {

	public void PlayGame(){
		if(SceneManager.sceneCount > 1){
			SceneManager.UnloadSceneAsync("HowToPlay");
		}else{
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1,LoadSceneMode.Single);
		}
        Time.timeScale = 1;
	}
	public void BackToMenu(){
		SceneManager.LoadScene("Menu",LoadSceneMode.Single);
	}
	public void QuitGame(){
		Debug.Log("QUITING");
		Application.Quit();
	}

}
