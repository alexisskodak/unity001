using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public Transform BulletPrefab;
    public Animator animator;
    public TextMeshProUGUI ammoText;

    bool isAutomatic;
    bool isReloading;
    float reloadTime;
    float damage;
    float bulletSpeed;
    float fireRate;
    int bulletCount;
    int clipSize;
    int totalAmmo;

    void Awake()
    {
        SetWeapon(20, 80, 50, 50, 0.7f, false, 30f);
    }

    void Update()
    {   
        if (Input.GetButtonDown("Fire1") && bulletCount > 0 && !isReloading)
        {
            Shoot();
        }

        if (!isReloading && (Input.GetButtonDown("Reload") && bulletCount < clipSize && totalAmmo > 0 || bulletCount == 0 && totalAmmo > 0))
        {
            StartCoroutine(Reload());
        }
    }

    void FixedUpdate()
    {
        PrintToGUI();
    }

    public void Shoot()
    {
        bool shootMode = animator.GetBool("ShootMode");
        if (shootMode == true)
        {
            Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
            bulletCount -= 1;
            animator.SetBool("IsShooting", true);
        }
    }

    IEnumerator Reload()
    {
        int bulletsToReload = clipSize - bulletCount;

        isReloading = true;
        animator.SetBool("isReloading", true);

        yield return new WaitForSeconds(reloadTime);

        if (bulletsToReload <= totalAmmo && bulletCount <= clipSize)
        {
            bulletCount += bulletsToReload;
            totalAmmo -= bulletsToReload;
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

    public void PrintToGUI()
    {
        ammoText = GameObject.Find("Ammo_Display").GetComponent<TextMeshProUGUI>();
        ammoText.text = PrintAmmo() + "    " + PrintTotalAmmo();
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetBulletVelocity()
    {
        return bulletSpeed;
    }

    public void SetWeapon(int cSize, int tBullets, float wDamage, 
                          float bSpeed, float rTime, bool aFire, float fRate)
    {   
        SetClipSize(cSize);
        SetTotalAmmo(tBullets);
        SetWeaponDamage(wDamage);
        SetBulletVelocity(bSpeed);
        SetReloadTime(rTime);
        SetAutoFire(aFire);
        SetFireRate(fRate);
    }

    public void SetClipSize(int cSize)
    {
        if(cSize > 0)
            clipSize = cSize;
        else
            clipSize = 7;
    }

    public void SetTotalAmmo(int tBullets)
    {
        if(tBullets > 0)
            totalAmmo = tBullets;
        else
            totalAmmo = 14;
    }

    public void SetWeaponDamage(float wDamage)
    {
        if(wDamage > 0)
            damage = wDamage;
        else
            damage = 5;
    }

    public void SetBulletVelocity(float bSpeed)
    {
        if(bSpeed > 0)
            bulletSpeed = bSpeed;
        else
            bulletSpeed = 10;
    }

    public void SetReloadTime(float rTime)
    {
        if(rTime > 0)
            reloadTime = rTime;
        else
            reloadTime = 0.5f;
    }

    public void SetAutoFire(bool aFire)
    {
        isAutomatic = aFire;
    }

    public void SetFireRate(float fRate)
    {
        if(fRate > 0)
            fireRate = fRate;
        else
            fireRate = 30;
    }
}
