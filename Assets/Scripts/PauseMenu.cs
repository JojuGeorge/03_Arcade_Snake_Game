using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public string mainMenu;
    bool isPaused;

    public GameObject pauseMenuCanvas;

    void Start()
    {
        isPaused = false;
    }

    void Update()
    {
        if (isPaused) {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenuCanvas.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
    }

    public void Resume()
    {
        isPaused = false;
    } 

    public void PauseButton()
    {
        isPaused = true;
    }

    public void Home()
    {
        Application.LoadLevel(mainMenu);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
