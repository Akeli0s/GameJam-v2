using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    public float bulletSpeed;
    Vector2 direction;

    private void Start()
    {
        player = GameObject.Find("type1");
        Vector2 direction = player.transform.position - transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
