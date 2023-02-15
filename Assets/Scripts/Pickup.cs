using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int amount = 10;
    [SerializeField]
    bool alwaysTrack = false;
    public int Amount
    {
        get { return amount; }
    }
    float movespeed = 2;

    Transform playerTransform;
    Vector3 direction;
    Rigidbody2D body;

    void Start()
    {
        if (alwaysTrack)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            playerTransform = player.transform;

            body = GetComponent<Rigidbody2D>();


        }
    }

    // Update is called once per frame
    void Update()
    {
        if (alwaysTrack)
        {
            direction = playerTransform.position - transform.position;
            direction.Normalize();
            body.velocity = direction * movespeed;

        }
    }
}
