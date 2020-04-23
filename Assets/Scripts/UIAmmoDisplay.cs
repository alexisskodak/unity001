using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIAmmoDisplay : MonoBehaviour
{
    public Weapon cWeapon;
    public TextMeshProUGUI aText;

    void Start()
    {
        cWeapon = GameObject.Find("FirePoint").GetComponent<Weapon>();
        aText.text = "text";
    }

    void FixedUpdate()
    {
        aText.text = cWeapon.PrintAmmo();
    }
}
