using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class SHouts : MonoBehaviour
{
    public AudioClip audio0;
    public AudioClip audio1;
    public AudioClip audio2;
    public AudioClip audio3;
    private int rng;
    private int count = 0;
    void FixedUpdate()
    {
        if (count == 10)
        {
            this.GetComponent<AudioSource>().enabled = true;
            rng = Random.Range(0, 3);


            if (rng == 0)
            {
                this.GetComponent<AudioSource>().clip = audio0;

            }
            if (rng == 1)
            {
                this.GetComponent<AudioSource>().clip = audio1;

            }
            if (rng == 2)
            {
                this.GetComponent<AudioSource>().clip = audio2;
            }
            if (rng == 3)
            {
                this.GetComponent<AudioSource>().clip = audio3;
            }
            count = 0;
        }
        else
        {
            this.GetComponent<AudioSource>().enabled = false;
            count++;
        }
    }
}
