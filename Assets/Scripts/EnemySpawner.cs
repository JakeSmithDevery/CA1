using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameManager gameManager;

    public GameObject Enemy1Prefab;
    public GameObject Enemy2Prefab;
    public int rand;
    

    public float spawnTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        gameManager = go.GetComponent<GameManager>();

        InvokeRepeating("SpawnEnemy",spawnTime, spawnTime);

    }

    void SpawnEnemy()
    {
        if(gameManager.CanSpawnEnemy())
        {
            rand = Random.Range(1, 10);

            

            if (rand % 2 == 0)
            {
               Instantiate(Enemy1Prefab, transform.position, Quaternion.identity);
                gameManager.RecordEnemySpawned();
            }
            else
            {
                Instantiate(Enemy2Prefab, transform.position, Quaternion.identity);
                gameManager.RecordEnemySpawned();
            }
        }
    }
   
}
