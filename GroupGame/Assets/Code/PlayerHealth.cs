using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthSystm healthbar;
    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player took " + amount + " damage. Current health: " + currentHealth);
        healthbar.SetHealth(currentHealth);
        GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
        if (currentHealth <= 0)
        {
            Die();

            healthbar.SetHealth(currentHealth);
        }
    }

    void Die()
    {
        Debug.Log("Player died!");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    public void AddMaxHealth(int HealthIncrease)
    {
        maxHealth += HealthIncrease;
        healthbar.SetMaxHealth(maxHealth);
        
    }
}