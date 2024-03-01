using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemySpawnPoints;

    [SerializeField]
    GameObject[] enemyPrefabs;

    [SerializeField]
    float spawnTime;

    [SerializeField]
    int maxEnemies;

    private int currentEnemies = 1;

    private void Start()
    {
        spawnTimer = spawnTime;
    }

    //these three helper functions just allow the enemy controller class to adjust the enemy count we have in this class before it destroys that instance of an enemy.
    public int GetCurrentEnemyCount()
    {
        return currentEnemies;
    }

    public void AddToEnemyCount()
    {
        currentEnemies += 1;
    }

    public void TakeFromEnemyCount()
    {
        if (currentEnemies > 0 )
        {
            currentEnemies -= 1;
        }
    }

    void EnemySpawnerHandler()
    {
        if (currentEnemies < maxEnemies)
        {
            EnemySpawnerFunc();
        }
        else
        {
            return;
        }
    }

    float spawnTimer;
    void EnemySpawnerFunc()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].transform.position, Quaternion.identity); // add a function that spawns enemies based on a percentage rarity
            AddToEnemyCount();
            spawnTimer = spawnTime;
        }
    }

    private void Update()
    {
        EnemySpawnerHandler();
    }
}
