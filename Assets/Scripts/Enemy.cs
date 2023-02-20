using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MovementSpeed = 10;
    public int Damage = 5;
    float horizontal;
    float vertical;
    float DashTime = 1.5f;
    float DashCooldown = 5;
    public bool DashOn;

    GameManager gameManager;
    Rigidbody2D body;
    Vector2 direction;
    GameObject player;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        gameManager = go.GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void Update()
    {
        direction = player.transform.position - transform.position;
        direction.Normalize();
        transform.up = direction;

        body.velocity = direction * MovementSpeed;

        if(DashOn)
        {
            InvokeRepeating("MovespeedSlow", 1, 10);
            InvokeRepeating("Dash", DashTime, 10);
            InvokeRepeating("normaliseSpeed", 3, 10);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        gameManager.RecordEnemyDestroyed();
        Destroy(gameObject);
        
    }

    private void MovespeedSlow()
    {
        MovementSpeed = 0;
    }

    private void Dash()
    {
        MovementSpeed = 15;
    }

    private void normaliseSpeed()
    {
        MovementSpeed = 10;
    }



}
