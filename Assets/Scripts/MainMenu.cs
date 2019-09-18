using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string loadLevel;
    public string creditScene;

    private void Start()
    {
        ScoreManager.ResetScore();

    }

    public void StartNewGame() {
        Application.LoadLevel(loadLevel);
    }

    public void Credits()
    {
        Application.LoadLevel(creditScene);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
