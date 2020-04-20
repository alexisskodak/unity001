using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{   
    public int bulletCount;
    public Transform FirePoint;
    public Transform BulletPrefab;
    public Animator animator;

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

    void Shoot()
    {   
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        bulletCount -= 1;
    }
}
