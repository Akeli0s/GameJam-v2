using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject health4;
    public GameObject health5;

    private GameObject player;
    private PlayerMovement playerHealth;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (playerHealth.health == 4)
        {
            health5.SetActive(false);
        }
        else if (playerHealth.health == 3)
        {
            health4.SetActive(false);
        }
        else if (playerHealth.health == 2)
        {
            health3.SetActive(false);
        }
        else if (playerHealth.health == 1)
        {
            health2.SetActive(false);
        }
        else if (playerHealth.health == 0)
        {
            health1.SetActive(false);
        }
    }
}
