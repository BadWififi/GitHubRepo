using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemySpawner enemySpawning;
    public int maxHealth = 100;          
    private int currentHealth;          

    void Start()
    {
        currentHealth = maxHealth;       
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy Health: " + currentHealth); 

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died");

        enemySpawning = FindObjectOfType<EnemySpawner>();
        if (enemySpawning != null)
        {
            enemySpawning.enemiesInRoom--;  
        }

        Destroy(gameObject);
    }
}
