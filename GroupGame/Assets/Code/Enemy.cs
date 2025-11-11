using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private EnemySpawner enemySpawning;

    public bool isAttacking = false;
    public int maxHealth = 100;
    int currentHealth;
    public int score = 0;

    public float attackCooldown = 1.5f;
    public int attackDamage = 20;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;

    public SpriteRenderer spriteRenderer;
    public Sprite Damaged;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
        ChangeSprite();

        if (currentHealth <= 0)
        {
            Die();
            score++;
            Debug.Log(score);
        }
    }

    void Die()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        Debug.Log("Enemy Died");
        if (activeScene.name == "InfiniteLevel")
        {
            Destroy(gameObject);
        }
        else
        {
            GameObject.Find("Enemy").SetActive(false);
        }
        
    }
    void ChangeSprite()
    {
        spriteRenderer.sprite = Damaged;
    }


}
