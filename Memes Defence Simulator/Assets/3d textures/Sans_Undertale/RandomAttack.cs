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
    private GameObject player;
    private int rng;
    public float currentTime = 0;
    public float timeDiff = 3;


    private Transform playerPos;
    private Vector3 pPos;
    private Quaternion pRot;
    private IEnumerator firstAttackCoroutine;
    private IEnumerator secondAttackCoroutine;
    private IEnumerator therdAttackCoroutine;
    private int rAttackPosiX;
    private int rAttackPosiZ;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        
        if (currentTime + timeDiff <= Time.time)
        {
            currentTime = Time.time;
            rng = new System.Random().Next(3);

            switch (rng)
            {
                case 0:

                    firstAttackCoroutine = Firstattack();
                    StartCoroutine(firstAttackCoroutine);

                    break;
                case 1:
                    if (firstAttackCoroutine == null && secondAttackCoroutine == null && therdAttackCoroutine == null)
                    {

                        secondAttackCoroutine = Secondattack();
                        StartCoroutine(secondAttackCoroutine);


                    }
                    break;
                case 2:
                    if (firstAttackCoroutine == null && secondAttackCoroutine == null && therdAttackCoroutine == null)
                    {

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
        pRot = playerPos.rotation;
        Instantiate(attack1Warning, pPos, pRot);
        var attackWarn = GameObject.FindGameObjectsWithTag("Attack1Warning");
        for (int i = 0; i < attackWarn.Length; i++)
        {
            attackWarn[i].GetComponent<AudioSource>().Play();
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < attackWarn.Length; i++)
        {
            Destroy(attackWarn[i]);
        }
        Instantiate(attack1, pPos, pRot);
        var attack = GameObject.FindGameObjectsWithTag("Attack1");
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < attack.Length; i++)
        {
            Invoke("DelayAR", 0.5f);
        }
        StopCoroutine(firstAttackCoroutine);
        firstAttackCoroutine = null;

    }
    private void DelayAR()
    {
        var attack = GameObject.FindGameObjectsWithTag("Attack1");
        Destroy(attack[0]);
    }
    private IEnumerator Secondattack()
    {
        
        var array = new int[] { 1, -1 };

        array = new int[] { 1, -1 };
        
        playerPos = player.GetComponent<Transform>();
        pPos = playerPos.position;
        pRot = playerPos.rotation;
        rAttackPosiX = (int)array[Random.Range(0, array.Length)] * 30;
        rAttackPosiZ = (int)array[Random.Range(0, array.Length)] * 15;
        pPos.z = pPos.z + (float)rAttackPosiZ;
        pPos.x = pPos.x + (float)rAttackPosiX;
        pRot.x = 0;
        pRot.y = 0;
        pRot.z = 0;
        Instantiate(attack2, pPos, pRot);
        rAttackPosiX = (int)array[Random.Range(0, array.Length)] * 15;
        rAttackPosiZ = (int)array[Random.Range(0, array.Length)] * 30;
        pPos.z = pPos.z + (float)rAttackPosiZ;
        pPos.x = pPos.x + (float)rAttackPosiX;
        pRot.x = 0;
        pRot.y = 0;
        pRot.z = 0;
        Instantiate(attack2, pPos, pRot);
        rAttackPosiX = (int)array[Random.Range(0, array.Length)] * 15;
        rAttackPosiZ = (int)array[Random.Range(0, array.Length)] * 15;
        pPos.z = pPos.z + (float)rAttackPosiZ;
        pPos.x = pPos.x + (float)rAttackPosiX;
        pRot.x = 0;
        pRot.y = 0;
        pRot.z = 0;
        Instantiate(attack2, pPos, pRot);
        var attacks = GameObject.FindGameObjectsWithTag("Attack2");
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < attacks.Length; i++)
        {
            attacks[i].GetComponent<AudioSource>().Play();
            attacks[i].GetComponentInChildren<Animator>().enabled = true;
            attacks[i].GetComponent<LooakAtForAt>().enabled = false;
        }
        yield return new WaitForSeconds(1.2f);
        attacks = GameObject.FindGameObjectsWithTag("Attack2");
        for (int i = 0; i < attacks.Length; i++)
        {
            Destroy(attacks[i]);
        }

        StopCoroutine(secondAttackCoroutine);
        secondAttackCoroutine = null;

    }

    private IEnumerator Therdattack()
    {
        var array = new int[] { 1, -1, 2, -2, 3, -3, 4, -4 };

        array = new int[] { 1, -1, 2, -2, 3, -3, 4, -4 };
        var MobPos = this.GetComponent<Transform>().position;
        MobPos.x = MobPos.x + (int)array[Random.Range(0, array.Length)] * 4;
        MobPos.y = MobPos.y + Mathf.Abs((int)array[Random.Range(0, array.Length)]*2);
        pRot.x = 0;
        pRot.y = 0;
        pRot.z = 0;
        Instantiate(attack3, MobPos, pRot);
        MobPos = this.GetComponent<Transform>().position;
        MobPos.x = MobPos.x + (int)array[Random.Range(0, array.Length)] * 4;
        MobPos.y = MobPos.y + Mathf.Abs((int)array[Random.Range(0, array.Length)] * 2); 
        Instantiate(attack3, MobPos, pRot);
        MobPos = this.GetComponent<Transform>().position;
        MobPos.x = MobPos.x + (int)array[Random.Range(0, array.Length)] * 4;
        MobPos.y = MobPos.y + Mathf.Abs((int)array[Random.Range(0, array.Length)] * 2);
        Instantiate(attack3, MobPos, pRot);
        var attacks = GameObject.FindGameObjectsWithTag("Attack3");
        for (int i = 0; i < attacks.Length; i++)
        {
            attacks[i].GetComponent<AudioSource>().Play();
        }
        yield return new WaitForSeconds(0.25f);
        for (int i = 0; i < attacks.Length; i++)
        {
            attacks[i].GetComponent<LooakAtForAt>().enabled = false;
        }
        yield return new WaitForSeconds(0.25f);
        for (int i = 0; i < attacks.Length; i++)
        {
            attacks[i].GetComponentInChildren<Animator>().enabled = true;
        }
        var attackfire = GameObject.FindGameObjectsWithTag("Attack3Fire");
        var attackaudio = GameObject.FindGameObjectsWithTag("Attack3Sound");
        for (int i = 0; i < attacks.Length; i++)
        {
            attacks[i].GetComponent<LooakAtForAt>().enabled = false;
        }

        attackaudio[0].GetComponent<AudioSource>().Play();

        for (int i = 0; i < attackfire.Length; i++)
        {
            attackfire[i].GetComponent<MeshRenderer>().enabled = true;
            attackfire[i].GetComponent<CapsuleCollider>().enabled = true;
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < attackfire.Length; i++)
        {
            Destroy(attackfire[i]);
        }
        for (int i = 0; i < attacks.Length; i++)
        {
            Destroy(attacks[i]);
        }

        StopCoroutine(therdAttackCoroutine);
        therdAttackCoroutine = null;


    }


}
