using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    Text text;
    public Image img1,img2;
    public float maxTime;
    float currentTime;

    public string gameOverScreen;
    SnakeController snake;

    public float fadeDelay;
    float fadeTimer;

    void Start()
    {

        text = GetComponent<Text>();
        currentTime = maxTime;
        snake = FindObjectOfType<SnakeController>();
        fadeTimer = fadeDelay;
        img1.enabled = false;
        img2.enabled = false;

    }

    void Update()
    {
        text.text = " " + Mathf.Round(currentTime);
        currentTime -= Time.deltaTime;

        if (currentTime <= 0) {

            snake.moveSpeed = 0;
            snake.tail.Clear();

            img1.enabled = true;
            img2.enabled = true;
            fadeTimer -= Time.deltaTime;
            if (fadeTimer <= 0) {
                Application.LoadLevel(gameOverScreen);
                img1.enabled = false;
                img2.enabled = false;
            }
            currentTime = 0;
        }
        if(currentTime <= 11)
        {
            text.color = Color.red;
        }


    }
}
