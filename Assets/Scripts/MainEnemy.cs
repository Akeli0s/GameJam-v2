using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemy : MonoBehaviour
{
    private GameObject toxicTimer;
    private ToxicTimer toxTimer;

    private void Start()
    {
        toxicTimer = GameObject.Find("Toxic Timer");
        toxTimer = toxicTimer.GetComponent<ToxicTimer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            toxTimer.antidotesGathered++;
            Destroy(gameObject);
        }
    }
}
