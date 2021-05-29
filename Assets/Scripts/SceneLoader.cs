using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    GameStatus gs;
    
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        FindObjectOfType<GameStatus>().ResetGame();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResetLevel()
    {
        gs = FindObjectOfType<GameStatus>();
        gs.LevelInit(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ;
    }

    public void PlayAgain()
    {
        FindObjectOfType<GameStatus>().ResetGame();
        SceneManager.LoadScene("Level 1");
       
    }
}
