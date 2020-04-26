using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g18 : MonoBehaviour
{   
    public Weapon glock18;

    private void Start() 
    {   
        glock18.SetWeapon(18, 72, 25, 50, .3f, true, 50);
    }

    private void Update()
    {
        glock18.Shoot();
    }
}
