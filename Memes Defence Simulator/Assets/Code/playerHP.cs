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
    public static bool PlayerDead = false;
    public GameObject back;
    public void TakeHit(int dmg)
    {
        if (HP-dmg <= 0 && PlayerDead == false)
        {   

            PlayerDead = true;
            AudioListener.volume = 0;
            this.GetComponent<AudioListener>().enabled = false;
            back.SetActive(true);
            var Dead = GameObject.FindGameObjectWithTag("DEAD");
            Dead.GetComponent<DeathS>().Death();
            Invoke("Delay", 10);
            Debug.Log("Dead");

        }
        HP -= dmg;
    }
    private void Delay()
    {
        Application.Quit();
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
