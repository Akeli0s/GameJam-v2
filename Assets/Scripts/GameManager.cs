using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public ToxicTimer toxTimer;
    private GameObject player;
    private PlayerMovement playerHealth;
    private GameObject timerGO;
    private Timer timer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timerGO = GameObject.Find("Timer");
        timer = timerGO.GetComponent<Timer>();
        playerHealth = player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (toxTimer.toxTimer < 1)
        {
            timer.timerStarts = false;
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
        }

        if (playerHealth.health < 1)
        {
            timer.timerStarts = false;
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
        }
    }
}
