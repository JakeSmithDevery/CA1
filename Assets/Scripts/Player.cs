using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10;
    public GameObject BulletPrefab;
    public int Health = 100;
    public float BulletSpeed = 20;
    float horizontal;
    float vertical;
    Rigidbody2D body;
    Vector2 velocity;
    Vector3 MousePosition;
    Vector3 direction;
    GameManager gameManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        gameManager = go.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        velocity.x = horizontal * moveSpeed;
        velocity.y = vertical * moveSpeed;

        body.velocity = velocity;

        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePosition.z = 0;

        direction = MousePosition - transform.position;
        direction.Normalize();
        transform.up = direction;

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if(Health <= 0)
        {
            Application.Quit();
        }
        
        


    }
    void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D body = bullet.GetComponent<Rigidbody2D>();
        body.velocity = direction * BulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Health -= enemy.Damage;
            Destroy(collision.gameObject);
            gameManager.RecordEnemyDestroyed();
            
        }
    }




}
