using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;        
        SceneManager.LoadScene(currentScene + 1);
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
        GameStatus status = FindObjectOfType<GameStatus>();
        status.resetTheScore();
    }

    public void quitTheScene()
    {
        Application.Quit();
    }
}
