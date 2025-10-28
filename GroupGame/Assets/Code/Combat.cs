using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Combat : MonoBehaviour
{

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public int parryDamage = 20;
    public float parryPushForce = 5f;

    private bool isAttacking = false;
    private float attackCooldown = 0.3f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            StartCoroutine(Attack());
        }

    }

    IEnumerator Attack()
    {

        isAttacking = true;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemyCollider in hitEnemies)
        {
            Enemy enemy = enemyCollider.GetComponent<Enemy>();

            if (enemy != null)
            {
                if (enemy.isAttacking)
                {
                    Parry(enemy);
                }
                else
                {
                    enemy.TakeDamage(attackDamage);
                }
            }
        }

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;

    }

    void Parry(Enemy enemy)
    {
        Debug.Log("Parry Successful");

        enemy.TakeDamage(parryDamage);

        Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
        Rigidbody2D playerRb = GetComponent<Rigidbody2D>();

        if (enemyRb != null && playerRb != null)
        {
            Vector2 pushDirection = (enemy.transform.position - transform.position).normalized;

            enemyRb.AddForce(pushDirection * parryPushForce, ForceMode2D.Impulse);

            playerRb.AddForce(-pushDirection * (parryPushForce * 0.8f), ForceMode2D.Impulse);
        }
    }

    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

