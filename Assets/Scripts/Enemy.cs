using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public AIPath aiPath;
    private GameObject player;
    public GameObject firepoint;
    private Rigidbody2D rb;
    private AIDestinationSetter setTarget;
    private Quaternion rotation;
    private float timer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        GetComponentInParent<AIDestinationSetter>().target = player.transform;
        Vector2 direction = player.transform.position - firepoint.transform.position;
        float angle = MathF.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        timer += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (timer > 1.5)
            {
                timer = 0;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, firepoint.transform.position, Quaternion.identity);
    }
}
