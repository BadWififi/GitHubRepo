using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;         
    public GameObject[] enemies;             
    public float minTimeBetweenSpawns = 1f;  
    public float maxTimeBetweenSpawns = 3f;  

    public int enemiesInRoom = 0;            
    public bool spawnerDone = false;        

    private void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());  
    }

    IEnumerator SpawnEnemyCoroutine()
    {
        while (!spawnerDone)
        {
            if (spawnPoints.Length == 0 || enemies.Length == 0)
            {
                Debug.LogWarning("No spawn points or enemies configured.");
                yield break;
            }

            List<GameObject> validEnemies = new List<GameObject>();
            foreach (GameObject enemy in enemies)
            {
                if (enemy != null)
                    validEnemies.Add(enemy);
            }

            if (validEnemies.Count == 0)
            {
                Debug.LogError("All enemy prefabs are null or have been destroyed.");
                yield break;
            }

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            int enemyIndex = Random.Range(0, validEnemies.Count);

            GameObject spawnPoint = spawnPoints[spawnIndex];
            GameObject enemyPrefab = validEnemies[enemyIndex];

            Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            enemiesInRoom++;

            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void StopSpawning()
    {
        spawnerDone = true;
    }

    public void ResumeSpawning()
    {
        if (!spawnerDone)
            return;

        spawnerDone = false;
        StartCoroutine(SpawnEnemyCoroutine()); 
    }
}

