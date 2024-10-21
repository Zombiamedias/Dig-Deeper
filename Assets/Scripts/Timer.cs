using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeRemaining = 80f; 
    private bool timerIsRunning = true; 
    private Color originalColor; 

    void Start()
    {
        
        originalColor = timerText.color;
    }

    void Update()
    {
        
        if (timerIsRunning)
        {
            timeRemaining -= Time.deltaTime;

            
            if (timeRemaining < 0)
            {
                timeRemaining = 0;
                timerIsRunning = false; 
                GameOver();
            }

            
            if (timeRemaining <= 10f)
            {
                timerText.color = Color.red; 
            }
            else
            {
                timerText.color = originalColor;
            }

            
            string minutes = ((int)timeRemaining / 60).ToString("00");
            string seconds = (timeRemaining % 60).ToString("00.00");
            
            
            timerText.text = minutes + ":" + seconds;
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
