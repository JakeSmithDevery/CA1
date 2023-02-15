using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MovementSpeed = 10;
    public int Damage = 5;
    float horizontal;
    float vertical;

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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        gameManager.RecordEnemyDestroyed();
        Destroy(gameObject);
        
    }

}
