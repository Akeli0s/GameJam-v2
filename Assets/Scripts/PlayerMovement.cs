using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    public GameObject firePoint;
    public GameObject bullet;
    private Rigidbody2D rb;
    private float movementX;
    private float movementY;
    private Vector2 mousePos;
    private Quaternion rotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        Run();
        RotateOnMousePos();
        Shoot();
    }

    private void Run()
    {
        rb.velocity = new Vector2(movementX * moveSpeed, movementY * moveSpeed);
    }

    private void RotateOnMousePos()
    {
        mousePos = Input.mousePosition;
        Vector2 direction = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;

        float angle = MathF.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        transform.rotation = rotation;
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, firePoint.transform.position, rotation);
        }
    }
}

