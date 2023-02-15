using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int MaxAllowedEnemies = 20;
    public int CurrentNumberOfEnemies;

    public bool CanSpawnEnemy()
    {
        if (CurrentNumberOfEnemies < MaxAllowedEnemies)
        {
            return true;
        }
        else
        {
            return false;
        }
    }    

    public void RecordEnemySpawned()
    {
        CurrentNumberOfEnemies++;
    }

    public void RecordEnemyDestroyed()
    {
        CurrentNumberOfEnemies--;
    }
}
