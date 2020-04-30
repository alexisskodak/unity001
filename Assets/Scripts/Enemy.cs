using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{      
    Rigidbody2D rb2d;

    [SerializeField]
    Transform player;

    public Animator animator;
    public GameObject deathEffect;
    public HealthBar healthBar;

    float health;
    float moveSpeed;
    float agroRange;

    void Start()
    {   
        rb2d = GetComponent<Rigidbody2D>();
        SetAgroRange(10f);
        SetMovementSpeed(5f);
        SetHealth(100f);
    }

    void Update()
    {
        // distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer < GetAgroRange())
        {
            ChasePlayer();
        }
        else
        {
            StopChasePlayer();
        }
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.SetSize(health/100);
        if(health <= 0)
            Die();
            
        if(health < 30)
            healthBar.SetColor(Color.red);
    }

    public void ChasePlayer()
    {   
        animator.SetBool("isEngaging", true);
        if(transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }

        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    public void StopChasePlayer()
    {
        animator.SetBool("isEngaging", false);
        rb2d.velocity = new Vector2(0, 0);
    }

    public void SetHealth(float hp)
    {   
        if(hp >= 0f)
            health = hp;
        else
            health = 50f;
    }

    public void SetAgroRange(float aRange)
    {   
        if(aRange >= 0f)
            agroRange = aRange;
        else
            agroRange = 5f;
    }

    public void SetMovementSpeed(float mSpeed)
    {   
        if(mSpeed > 0f)
            moveSpeed = mSpeed;
        else
            moveSpeed = 10f;
    }

    public float GetHealth() {return health;}
    public float GetAgroRange() {return agroRange;}
    public float GetMovementSpeed() {return moveSpeed;}

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
