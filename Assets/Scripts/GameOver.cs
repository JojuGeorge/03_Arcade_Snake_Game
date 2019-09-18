using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public string mainMenu;

    private void Start()
    {
    }

    public void MainMenu()
    {
        Application.LoadLevel(mainMenu);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
