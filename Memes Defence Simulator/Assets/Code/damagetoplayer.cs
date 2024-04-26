using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class damagetoplayer : MonoBehaviour
{
    public int dmg = 10;
    public GameObject Player;
    public int imunitufram = 10;

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.tag == "Player")
        {
            playerHP HP = other.gameObject.GetComponent<playerHP>();
            HP.TakeHit(dmg);

        }

    }
    private void OnTriggerStay(UnityEngine.Collider other)
    {
        if (imunitufram == 10)
        {
            if (other.tag == "Player")
            {
                playerHP HP = other.gameObject.GetComponent<playerHP>();
                HP.TakeHit(dmg);

            }
            imunitufram = 0;
        }
        else
        {
            imunitufram++;
        }

    }
}
