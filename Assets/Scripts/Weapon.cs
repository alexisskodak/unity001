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

    int bulletCount;
    int totalBullets = 20;

    void Start()
    {
        SetBulletAmount();
    }

    void Update()
    {   
        if(Input.GetButtonDown("Fire1") && bulletCount > 0)
        {   
            bool shootMode = animator.GetBool("ShootMode");
            if (shootMode == true)
            {
                Shoot();
                animator.SetBool("IsShooting", true);
            }
        }

        if(Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("IsShooting", false);
        }
    }

    public void Shoot()
    {   
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        bulletCount -= 1;
    }

    public void SetBulletAmount()
    {
        bulletCount = totalBullets;
    }

    public string DisplayBulletCounter()
    {
        return bulletCount.ToString() + "/" + totalBullets.ToString();
    }
}
