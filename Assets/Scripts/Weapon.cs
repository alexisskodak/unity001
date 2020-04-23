using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    void Start()
    {   
        SetBulletAmount(50);
        SetClipSize(20);
        SetDamage(20);
        SetBulletVelocity(25);
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

    public void SetBulletAmount(int cBullets)
    {   
        totalAmmo = cBullets;
        bulletCount = totalAmmo;
    }

    public void SetClipSize(int cSize)
    {
        clipSize = cSize;
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

    public void SetDamage(float sDamage)
    {
        sDamage = damage;
    }

    public float GetBulletVelocity()
    {
        return bulletSpeed;
    }

    public void SetBulletVelocity(float bSpeed)
    {
        bulletSpeed = bSpeed;
    }
}
