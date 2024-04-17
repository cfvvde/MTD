using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class playerHP : MonoBehaviour
{
    public TextMeshProUGUI HP_overlay;
    public float HP = 1f;
    public float MaxHP = 100f;
    public float HpRegen = 0.1f;
    public void TakeHit(int dmg)
    {
        HP -= dmg;
    }
    void FixedUpdate()
    {


        if (HP < MaxHP)
        {
            HP += HpRegen;
        }
        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
        HP_overlay.text = "Health Points - " + HP.ToString("F0");
    }
}
