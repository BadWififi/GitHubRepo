using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float enemySpeed = 0.002f;
    public int damage = 20; // how much damage the enemy deals

    private float distance;
    private Rigidbody2D rb;
    bool IsPaused = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GameObject ShopUI = GameObject.FindWithTag("Shop");

        if (ShopUI != null)
        {
            IsPaused = true;
            if (IsPaused == true)
            {
                return;
            }
        }
        else
        {
            IsPaused = false;
        }
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance < 10)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.transform.position,
                enemySpeed + Time.deltaTime
            );
        }
    }


    // Damage player once when first touching
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }

    // If using triggers instead of collisions:
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}