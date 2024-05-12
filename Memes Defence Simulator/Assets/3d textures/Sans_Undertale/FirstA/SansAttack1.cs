using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SansAttack1 : MonoBehaviour
{
    public GameObject attack1;
    public GameObject attack1Warning;
    public GameObject player;
    private Transform playerPos;
    private Vector3 pPos;
    private Quaternion pRot;
    private GameObject attack;
    private GameObject attackWarn;
    public IEnumerator Firstattack()
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
        if (attack != null)
        { Destroy(attack); }

    }

}
