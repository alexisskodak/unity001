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
