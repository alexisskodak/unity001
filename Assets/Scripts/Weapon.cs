using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public Transform BulletPrefab;
    public Animator animator;

    float damage;
    float bulletSpeed;
    int bulletCount;
    int clipSize;
    int totalAmmo;

    void Awake()
    {   
        SetWeapon(18, 72, 10, 25);
    }

    void Update()
    {   
        Shoot();
    }

    public void Shoot()
    {   
        if(Input.GetButtonDown("Fire1") && bulletCount > 0)
        {   
            bool shootMode = animator.GetBool("ShootMode");
            if (shootMode == true)
            {
                Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
                bulletCount -= 1;
                animator.SetBool("IsShooting", true);
            }
        }

        if(Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("IsShooting", false);
        }
    }

    public string PrintAmmo()
    {
        return bulletCount.ToString() + "/" + clipSize.ToString();
    }

    public string PrintTotalAmmo()
    {
        return totalAmmo.ToString();
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetBulletVelocity()
    {
        return bulletSpeed;
    }

    public void SetWeapon(int cSize, int tBullets, float wDamage, float bSpeed)
    {
        clipSize = cSize;
        totalAmmo = tBullets;
        damage = wDamage;
        bulletSpeed = bSpeed;

        bulletCount = clipSize;
    }
}
