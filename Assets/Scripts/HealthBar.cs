using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{   
    private Transform bar;
    private SpriteRenderer hBar;

    private void Start()
    {
        bar = transform.Find("Bar");
        hBar = GameObject.Find("BarSprite").GetComponent<SpriteRenderer>();
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void SetColor(Color inputColor)
    {
        hBar.color = inputColor;
    }
}