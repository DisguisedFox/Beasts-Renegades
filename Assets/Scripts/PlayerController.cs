﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    GameObject bulletSpawner;


    private Vector2 direction;
    [SerializeField]
    private Sprite spriteUp;
    [SerializeField]
    private Sprite spriteDown;
    [SerializeField]
    private Sprite spriteLeft;
    [SerializeField]
    private Sprite spriteRight;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = spriteDown; // set the sprite to spriteDown
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        shoot();
    }

    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void GetInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            spriteRenderer.sprite = spriteUp;
            direction += Vector2.up;
            bulletSpawner.transform.rotation = Quaternion.Euler(0, 0 , 90);
        }

        if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.sprite = spriteLeft;
            direction += Vector2.left;
            bulletSpawner.transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        if (Input.GetKey(KeyCode.S))
        {
            spriteRenderer.sprite = spriteDown;
            direction += Vector2.down;
            bulletSpawner.transform.rotation = Quaternion.Euler(0, 0, 270);
        }

        if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.sprite = spriteRight;
            direction += Vector2.right;
            bulletSpawner.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, bulletPrefab.transform.position, gameObject.transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletPrefab.transform.right * 5.0f;
            Destroy(bullet, 2.0f);
        }
    }

}
