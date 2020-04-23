using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g18 : MonoBehaviour
{   
    public Weapon glock18;

    private void Start() 
    {   
        glock18.SetBulletAmount(36);
        glock18.SetClipSize(18);
        glock18.SetDamage(10);
        glock18.SetBulletVelocity(10);
    }

    private void Update()
    {
        glock18.Shoot();
    }
}
