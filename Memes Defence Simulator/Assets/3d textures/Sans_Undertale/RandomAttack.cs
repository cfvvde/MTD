using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomAttack : MonoBehaviour
{
    public GameObject attack1;
    public GameObject attack2;
    public GameObject attack3;  
    public GameObject attack1Warning;
    public GameObject player;
    private int rng;
    private float currentTime = 0;
    public float timeDiff = 3;
    private Transform playerPos;
    private Vector3 pPos;
    private Quaternion pRot;
    private GameObject attack;
    private GameObject attackWarn;
    private IEnumerator firstAttackCoroutine;
    private IEnumerator secondAttackCoroutine;
    private IEnumerator therdAttackCoroutine;
    private int rAttackPosiX;
    private int rAttackPosiZ;



    private void FixedUpdate()
    {
        
        if (currentTime + timeDiff <= Time.time)
        {
            currentTime = Time.time;
            rng = new System.Random().Next(3);

            switch (rng)
            {
                case 0:
                    if (firstAttackCoroutine == null)
                    {
                        if (attack == null)
                            firstAttackCoroutine = Firstattack();
                            StartCoroutine(firstAttackCoroutine);
                    }
                    break;
                case 1:
                    if (secondAttackCoroutine == null)
                    {   
                        if (attack == null)
                            secondAttackCoroutine = Secondattack();
                            StartCoroutine(secondAttackCoroutine);
                    }
                    break;
                case 2:
                    if (therdAttackCoroutine == null)
                    {   
                        if (attack == null)
                            therdAttackCoroutine = Therdattack();
                            StartCoroutine(therdAttackCoroutine);
                    }
                    break;
            }
        }
    }
    private IEnumerator Firstattack()
    {

        playerPos = player.GetComponent<Transform>();
        pPos = playerPos.position;
        Instantiate(attack1Warning, pPos, playerPos.rotation);
        attackWarn = GameObject.FindGameObjectWithTag("Attack1Warning");
        attackWarn.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        Destroy(attackWarn);
        Instantiate(attack1, pPos, playerPos.rotation);
        yield return new WaitForSeconds(3f);
        attack = GameObject.FindGameObjectWithTag("Attack1");
        Destroy(attack);

        firstAttackCoroutine = null;
    }
    private IEnumerator Secondattack()
    {
        var array = new int[] { 1, -1 };

        array = new int[] { 1, -1 };
        
        playerPos = player.GetComponent<Transform>();
        pPos = playerPos.position;
        pRot = playerPos.rotation;
        rAttackPosiX = (int)array[Random.Range(0, array.Length)] * 15;
        rAttackPosiZ = (int)array[Random.Range(0, array.Length)] * 15;
        pPos.z = pPos.z + (float)rAttackPosiZ;
        pPos.x = pPos.x + (float)rAttackPosiX;
        pRot.x = 0;
        pRot.y = 0;
        pRot.z = 0;
        Instantiate(attack2, pPos, pRot);
        attack = GameObject.FindGameObjectWithTag("Attack2");
        yield return new WaitForSeconds(1.5f);

        attack.GetComponent<AudioSource>().Play();
        attack.GetComponentInChildren<Animator>().enabled = true;
        attack.GetComponent<LooakAtForAt>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        attack = GameObject.FindGameObjectWithTag("Attack2");
        Destroy(attack);
        secondAttackCoroutine = null;
    }
    private IEnumerator Therdattack()
    {

        var MobPos = this.GetComponent<Transform>().position;
        MobPos.x = MobPos.x - 5f;
        MobPos.y = MobPos.y + 3f;
        pRot.x = 0;
        pRot.y = 0;
        pRot.z = 0;
        Instantiate(attack3, MobPos, pRot);
        attack = GameObject.FindGameObjectWithTag("Attack3");
        attack.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        attack.GetComponent<LooakAtForAt>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        attack.GetComponentInChildren<Animator>().enabled = true;
        var attackfire = GameObject.FindGameObjectWithTag("Attack3Fire");
        var attackaudio = GameObject.FindGameObjectWithTag("Attack3Sound");
        attack.GetComponent<LooakAtForAt>().enabled = false;
        attackaudio.GetComponent<AudioSource>().Play();
        attackfire.GetComponent<MeshRenderer>().enabled = true;
        attackfire.GetComponent<CapsuleCollider>().enabled = true;
        yield return new WaitForSeconds(2f);
        if (attackfire != null)
        {
            Destroy(attackfire);
        }
        yield return new WaitForSeconds(0.5f);
        if (attack != null)
        { 
            Destroy(attack);
        }
        
        therdAttackCoroutine = null;
    }


}
