using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToplayerSpecial : MonoBehaviour
{
    public int dmg = 10;
    public GameObject Main;
    private float imunitufram = 0f;
    public float imunitFrames = 0f;
    public AudioClip damageSound;


    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        Main.GetComponent<AudioSource>().clip = damageSound;

    }
    private void OnTriggerStay(UnityEngine.Collider other)
    {
        if (imunitufram >= imunitFrames)
        {
            if (other.tag == "Player")
            {
                Main.GetComponent<AudioSource>().Play();
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

