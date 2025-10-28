using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemySpawner enemySpawning;

    public bool isAttacking = false;
    public int maxHealth = 100;
    int currentHealth;
    public float numOfEnemyKilled = 0f;

    public float attackCooldown = 1.5f;
    public int attackDamage = 20;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;


    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        Collider2D hitPlayer = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayers);

        if (hitPlayer && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

   
    public IEnumerator Attack()
    {
        isAttacking = true;

        
        Debug.Log("Enemy attacking!");

        yield return new WaitForSeconds(0.2f);

        Collider2D hitPlayer = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayers);

        if (hitPlayer != null)
        {

            Debug.Log("Enemy hit the player!");
        }

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
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
        GameObject.Find("Enemy").SetActive(false);
        numOfEnemyKilled++;
        Debug.Log(numOfEnemyKilled.ToString());
    }
}
