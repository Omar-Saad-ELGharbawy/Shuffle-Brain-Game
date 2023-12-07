using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{

    // Pause the current game
    public void Pause()
    {
        Time.timeScale = 0;
    }

    // Resume the paused game
    public void Resume()
    {
        Time.timeScale = 1;
    }

    // Retry the game after game over
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    // Go to main menu
    public void MainMenu()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(0);
    }
}
