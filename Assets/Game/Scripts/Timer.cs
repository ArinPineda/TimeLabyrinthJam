using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public TMP_Text timerText;
    public static Timer instance;
    public bool timerIsRunning = true;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
          
        }
        else
        {
            Destroy(this);
        }

    }



    void Update()
    {

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                //  timerText.text = timeRemaining.ToString();
                DisplayTime(timeRemaining);
                GameManager.instance.FreezePlayer();
            }
        }
        else
        {

        }
       
        
        
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }



    public void RestartTimer() {

        timeRemaining = 60;
    }



}
