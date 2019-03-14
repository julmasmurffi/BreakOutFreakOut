using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {



    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        ///reset the player score at the start screen
        FindObjectOfType<GameStatus>().ResetScore();

        SceneManager.LoadScene(0);

        ///TODO add to high scores?
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
