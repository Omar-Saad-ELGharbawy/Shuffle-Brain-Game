using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    // public LevelManager levelManager;
    public Shuffle shuffle;

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        
    }

    // public void Retry()
    // {
    //     string currentScene = SceneManager.GetActiveScene().name;
    //     SceneManager.LoadScene(currentScene);
    //     // Time.timeScale= 1;
    //     shuffle.StartShuffling();
    //     // shuffle.FlipAllCards();
    // }

    void ReturnTime(){
        Time.timeScale= 1;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
