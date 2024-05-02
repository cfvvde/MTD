using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class damagetoplayer : MonoBehaviour
{
    public int dmg = 10;
    public GameObject Main;
    private int imunitufram = 10;
    public int imunitFrames = 20;
    public AudioClip damageSound;


    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        Main.GetComponent<AudioSource>().clip = damageSound;

    }
    private void OnTriggerStay(UnityEngine.Collider other)
    {
        if (imunitufram == imunitFrames)
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
