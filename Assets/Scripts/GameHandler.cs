using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{   
    [SerializeField] private HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetSize(1f); 
    }
}
