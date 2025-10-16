using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemySpawner enemySpawning;

    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died");

<<<<<<< HEAD
        Destroy(gameObject);

        enemySpawning = FindObjectOfType<EnemySpawner>();
        enemySpawning.enemiesInRoom--;

        if (enemySpawning.spawnTime <= 0 && enemySpawning.enemiesInRoom <= 0)
        {
            enemySpawning.spawnerDone = true;
        }
    }
=======
        //Destroy(gameObject);
        // Destroying game object throws an error, trialing disabling instead
        GameObject.Find("Enemy").SetActive(false);
        // Code below throws error "NullReferenceException: Object reference not set to an instance of an object" so i commented it out to make the game work
        
        //enemySpawning = FindObjectOfType<EnemySpawner>();
        //enemySpawning.enemiesInRoom--;
        //if (enemySpawning.spawnTime <= 0 && enemySpawning.enemiesInRoom <= 0)
        //{
        //    enemySpawning.spawnerDone = true;
        //}
    }


>>>>>>> 390f9cc7a2c84987ed5224d7de15f0353e5c8b73
}
