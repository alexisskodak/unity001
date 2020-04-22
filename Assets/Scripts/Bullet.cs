using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    float damageToDeal;
    public Weapon dWeapon;
    
    void Start()
    {
        rb.velocity = transform.right * speed;
        dWeapon = GameObject.Find("FirePoint").GetComponent<Weapon>();
        damageToDeal = dWeapon.damage;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {   
            enemy.TakeDamage(damageToDeal);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
