using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyScript : MonoBehaviour
{
    public int MobHP = 100;
    public Slider Healthbar;
    public GameObject DeathAnim;
    public GameObject Target;
    public GameObject main;
    public GameObject texture;


    void Update()
    {
        Healthbar.value = MobHP;
    }
    void Delay()
    {

        Destroy(main);
    }
    public void TakeDamage(int DamageAmount)
    {
        MobHP -= DamageAmount;
        if (MobHP <= 0)
        {
            main.GetComponent<NavMeshAgent>().enabled = false;
            if (texture != null)
                texture.SetActive(false);
            Target.SetActive(false);
            DeathAnim.SetActive(true);
            Invoke("Delay", 2.0f);
        }
        else
        {

        }

    }
}
