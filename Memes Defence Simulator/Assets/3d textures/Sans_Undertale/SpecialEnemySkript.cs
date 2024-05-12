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
    public GameObject Drop;

    void Update()
    {
        
    }
    void Delay()
    {
        var posit = main.transform.position;
        var rotat = main.transform.rotation;
        Instantiate(Drop, posit, rotat);
        var attack1 = GameObject.FindGameObjectsWithTag("Attack1");
        var attack2 = GameObject.FindGameObjectsWithTag("Attack2");
        var attack3 = GameObject.FindGameObjectsWithTag("Attack3");
        var attack1Warn = GameObject.FindGameObjectsWithTag("Attack1Warning");
        var attack3fire = GameObject.FindGameObjectsWithTag("Attack3Fire");
        for (int i = 0; i < attack1.Length; i++)
        {
            Destroy(attack1[i]);
        }
        for (int i = 0; i < attack2.Length; i++)
        {
            Destroy(attack2[i]);
        }
        for (int i = 0; i < attack3.Length; i++)
        {
            Destroy(attack3[i]);
        }
        for (int i = 0; i < attack1Warn.Length; i++)
        {
            Destroy(attack1Warn[i]);
        }
        for (int i = 0; i < attack3fire.Length; i++)
        {
            Destroy(attack3fire[i]);
        }
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
            var attack1 = GameObject.FindGameObjectsWithTag("Attack1");
            var attack2 = GameObject.FindGameObjectsWithTag("Attack2");
            var attack3 = GameObject.FindGameObjectsWithTag("Attack3");
            var attack1Warn = GameObject.FindGameObjectsWithTag("Attack1Warning");
            var attack3fire = GameObject.FindGameObjectsWithTag("Attack3Fire");
            for (int i = 0; i < attack1.Length; i++)
            {
                Destroy(attack1[i]);
            }
            for (int i = 0; i < attack2.Length; i++)
            {
                Destroy(attack2[i]);
            }
            for (int i = 0; i < attack3.Length; i++)
            {
                Destroy(attack3[i]);
            }
            for (int i = 0; i < attack1Warn.Length; i++)
            {
                Destroy(attack1Warn[i]);
            }
            for (int i = 0; i < attack3fire.Length; i++)
            {
                Destroy(attack3fire[i]);
            }
        }
        else
        {

        }

    }
}