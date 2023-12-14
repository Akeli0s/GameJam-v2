using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public AIPath aiPath;
    private GameObject player;
    public GameObject firepoint;
    private Rigidbody2D rb;
    private Quaternion rotation;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector2 direction = player.transform.position - firepoint.transform.position;
        float angle = MathF.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("yeyeyaya");
        if (collision.gameObject.CompareTag("Player"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, firepoint.transform.position, rotation);
    }
}
