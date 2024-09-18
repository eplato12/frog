using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public float timeLeft;
    public Text timerText;
    public bool timerOn;

    void Start()
    {
        timerOn = true;
    }

    void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
               timeLeft -= Time.deltaTime;
               updateTimer(timeLeft);
            }
        }
        else
        {
            timeLeft = 0;
            timerOn = false;
        }
    
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}