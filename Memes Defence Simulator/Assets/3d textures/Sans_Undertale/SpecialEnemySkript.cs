using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class SpecialEnemySkript : MonoBehaviour
{
    public int MobHP = 10;
    public GameObject DeathAnim;
    public GameObject Target;
    public GameObject main;
    public GameObject texture;
    public GameObject Miss;


    void Update()
    {
        
    }
    void Delay()
    {

        Destroy(main);
    }
    public void TakeDamage()
    {
        MobHP -= 1;
        Instantiate(Miss, main.transform);
        var MISS = GameObject.FindWithTag("MISS");
        var miss = GameObject.FindWithTag("Miss");
        var miss1 = GameObject.FindWithTag("Miss1");
        miss.GetComponent<Animator>().enabled = true;
        miss1.GetComponent<Animator>().enabled = true;
        Destroy(MISS, 0.40f);
        if (MobHP <= 0)
        {
            main.GetComponent<NavMeshAgent>().enabled = false;
            Target.GetComponent<AudioSource>().enabled = false;
            if (texture != null)
                texture.SetActive(false);
            main.GetComponent<BoxCollider>().enabled = false;
            Target.SetActive(false);
            DeathAnim.SetActive(true);
            Invoke("Delay", 2.0f);
        }
        else
        {

        }

    }
}