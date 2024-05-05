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

    private Transform playerCameraP;
    private int prng = 0;
    private Transform playerPos;
    private Vector3 pPos;
    private Quaternion pRot;
    private GameObject attack;
    private GameObject attackWarn;
    private IEnumerator firstAttackCoroutine;
    private IEnumerator secondAttackCoroutine;
    private IEnumerator therdAttackCoroutine;
    private IEnumerator fourthAttackCoroutine;




    private void FixedUpdate()
    {
        
        if (currentTime + timeDiff <= Time.time)
        {
            currentTime = Time.time;
            rng = new System.Random().Next(4);

            if (rng == prng)
                return;
            switch (rng)
            {
                case 0:
                    //if (firstAttackCoroutine == null)
                    //{
                    //    firstAttackCoroutine = Firstattack();
                    //    StartCoroutine(firstAttackCoroutine);
                    //}
                    break;
                case 1:
                    if (secondAttackCoroutine == null)
                    {
                        secondAttackCoroutine = Secondattack();
                        StartCoroutine(secondAttackCoroutine);
                    }
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
            }
            prng = rng;
        }
    }
    private IEnumerator Firstattack()
    {
        Debug.Log("First attack start");
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
        Debug.Log("First attack end");
        firstAttackCoroutine = null;
    }
    private IEnumerator Secondattack()
    {
        Debug.Log("Second attack start");
        playerPos = player.GetComponent<Transform>();
        pPos = playerPos.position;
        pRot = playerPos.rotation;
        pPos.z = pPos.z - 10f;
        pRot.x = 0;
        pRot.y = 0;
        pRot.z = 0;
        Instantiate(attack2, pPos, pRot);
        attack = GameObject.FindGameObjectWithTag("Attack2");
        attack.GetComponent<AudioSource>().Play();
        
        attack.GetComponentInChildren<Animator>().enabled = true;
        yield return new WaitForSeconds(3f);
        Destroy(attack);
        Debug.Log("Second attack end");
        secondAttackCoroutine = null;
    }

}
