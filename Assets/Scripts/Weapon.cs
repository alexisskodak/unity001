using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{   
    public int bulletCount;
    public Transform FirePoint;
    public Transform BulletPrefab;
    public Animator animator;
    //private float timeBtwShots;
    //public float startTimeBtwShots;

    void Update()
    {   
        float cSpeed = animator.GetFloat("Speed");

        if(cSpeed < 0.01f && cSpeed > 0f)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(-1f, 0f, rotZ);
        }

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
