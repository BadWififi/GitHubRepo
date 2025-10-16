using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private BossSpawner bossSpawning;

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
        Debug.Log("Boss Died");

        Destroy(gameObject);

        bossSpawning = FindObjectOfType<BossSpawner>();
        bossSpawning.enemiesInRoom--;

        if (bossSpawning.spawnTime <= 0 && bossSpawning.enemiesInRoom <= 0)
        {
            bossSpawning.spawnerDone = true;
        }
    }
}

