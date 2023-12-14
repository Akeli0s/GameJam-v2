using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverLowestTime;
    private float timerTime = 0;
    public bool timerStarts;

    private void Start()
    {
        timerStarts = true;
    }

    private void Update()
    {
        if (timerStarts == true)
        {
            timerTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(timerTime / 60);
            int seconds = Mathf.FloorToInt(timerTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            gameOverLowestTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
