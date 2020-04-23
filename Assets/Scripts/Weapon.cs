using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public Transform BulletPrefab;
    public Animator animator;
    public float damage;
    public float bulletSpeed;

    int bulletCount;
    int totalBullets;

    void Start()
    {   
        SetBulletAmount(50);
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
        totalBullets = cBullets;
        bulletCount = totalBullets;
    }

    public string PrintAmmo()
    {
        return bulletCount.ToString() + "/" + totalBullets.ToString();
    }
}
