using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public Transform BulletPrefab;
    public Animator animator;

    bool isReloading;
    float reloadTime;
    float damage;
    float bulletSpeed;
    int bulletCount;
    int clipSize;
    int totalAmmo;

    void Awake()
    {   
        SetWeapon(18, 36, 10, 25, .5f);
    }

    void Update()
    {   
        Shoot();
    }

    public void Shoot()
    {   
        if(Input.GetButtonDown("Fire1") && bulletCount > 0 && !isReloading)
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

        if(Input.GetButtonDown("Reload") && bulletCount < clipSize && totalAmmo > 0)
        {
            StartCoroutine(Reload());
        }

        if(bulletCount == 0 && totalAmmo > 0)
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {   
        int bulletsToReload = clipSize - bulletCount;
        Debug.Log(bulletsToReload.ToString());

        isReloading = true;
        animator.SetBool("isReloading", true);

        yield return new WaitForSeconds(reloadTime);

        Debug.Log(bulletsToReload.ToString());

        if(bulletsToReload <= totalAmmo) // si hay suficientes balas para un cargador completo
        {
            bulletCount += bulletsToReload; // balas en el cargador se vuelven a llenar
            totalAmmo -= bulletsToReload; // 
        }
        else
        {
            bulletCount += totalAmmo;
            totalAmmo -= totalAmmo;
        }

        isReloading = false;
        animator.SetBool("isReloading", false);
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

    public void SetWeapon(int cSize, int tBullets, float wDamage, float bSpeed, float rTime)
    {
        clipSize = cSize;
        totalAmmo = tBullets;
        damage = wDamage;
        bulletSpeed = bSpeed;
        reloadTime = rTime;

        bulletCount = clipSize;
    }
}
