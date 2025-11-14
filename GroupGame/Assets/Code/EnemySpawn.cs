using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int minEnemiesSpawned = 1;
    public int maxEnemiesSpawned = 2;
    public float minSpawnInterval = 5f;
    public float maxSpawnInterval = 8f;
    public float spawnRadius = 3f;

    public bool executed = false;
    Enemy enemy;
    public ScoreCounter scoreManager;
    public void Start()
    {
        StartCoroutine(SpawnEnemies());
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        scoreManager = scoreManager.GetComponent<ScoreCounter>();
        int score = scoreManager.score;
        executed = false;

    }
    public void Update()
    {
        int score = scoreManager.score;
        if (score == 3 && executed == false || score == 15 && executed == false) 
        {
            minEnemiesSpawned++;
            maxEnemiesSpawned++;
            Debug.Log("min enemies spawned is now: " + minEnemiesSpawned);
            Debug.Log("max enemies spawned is now: " + maxEnemiesSpawned);
            executed = true;
        }
        if (score == 10 && executed == true || score == 20 && executed == false)
        {
            minSpawnInterval--;
            maxSpawnInterval--;
            executed = false;
        }
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
