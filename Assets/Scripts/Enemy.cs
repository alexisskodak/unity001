using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public GameObject deathEffect;
    public HealthBar healthBar;
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.SetSize(health/100);
        if(health <= 0)
            Die();
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
