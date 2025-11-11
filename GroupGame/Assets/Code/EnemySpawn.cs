using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int minEnemiesSpawned = 1;
    public int maxEnemiesSpawned = 2;
    public float minSpawnInterval = 5f;
    public float maxSpawnInterval = 8f;
    public float spawnRadius = 3f;

    public void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public IEnumerator SpawnEnemies()
    {
        while(true)
        {
            float interval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(interval);

            int enemiesBatchSize = Random.Range(minEnemiesSpawned, maxEnemiesSpawned);
            for (int i = 0; i < enemiesBatchSize; i++)
            {
                Vector2 spawnPosition = (Vector2)gameObject.transform.position;

                Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

}
