using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIAmmoDisplay : MonoBehaviour
{
    public Weapon cWeapon;
    public TextMesh ammoDisplay;

    string ammo;
    
    void Start()
    {
        cWeapon = GameObject.Find("FirePoint").GetComponent<Weapon>();
        

    }

    void Update()
    {
        ammoDisplay.text = cWeapon.DisplayBulletCounter();
    }
}
