using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int minEnemiesSpawned = 1;
    public int maxEnemiesSpawned = 2;
    public float minSpawnInterval = 8f;
    public float maxSpawnInterval = 10f;
    public float spawnRadius = 2f;

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
