using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagetoplayer : MonoBehaviour
{
    public int dmg = 10;
    public GameObject Player;

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.tag == "Player")
        {
            playerHP HP = other.gameObject.GetComponent<playerHP>();
            HP.TakeHit(dmg);

        }

    }
}
