using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public bool isAttacking = false;
    public int maxHealth = 100;
    int currentHealth;

    public float attackCooldown = 1.5f;
    public int attackDamage = 20;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;

    public SpriteRenderer spriteRenderer;
    public Sprite Damaged;
    public Sprite Normal;

    public GameManager money;
    

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
        StartCoroutine(DamageIndicator());
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        Debug.Log("Enemy Died");
        if (activeScene.name == "InfiniteLevel")
        {
            ScoreCounter.instance.AddPoint();
            Destroy(gameObject);
            money.Bread += 5;
            Debug.Log(money.Bread);
        }
        else
        {
            Destroy(gameObject);
            money.Bread += 5;
            Debug.Log(money.Bread);
        }
        
    }

    public IEnumerator DamageIndicator()
    {
        spriteRenderer.sprite = Damaged;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.sprite = Normal;
    }

}
