using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public Weapon dWeapon;

    float bSpeed;
    float damageToDeal;
    
    void Start()
    {   
        dWeapon = GameObject.Find("FirePoint").GetComponent<Weapon>();
        damageToDeal = dWeapon.GetDamage();
        bSpeed = dWeapon.GetBulletVelocity();
        rb.velocity = transform.right * bSpeed;
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
