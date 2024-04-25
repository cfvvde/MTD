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
    float currentTime = 0;
    float timeDiff = 3;

    private void FixedUpdate()
    {
        if (currentTime + timeDiff <= Time.time)
        {
            currentTime = Time.time;
            this.GetComponent<AudioSource>().enabled = true;
            rng = Random.Range(0, 3);
            if (rng == 0)
            {
                this.GetComponent<AudioSource>().clip = audio0;
                this.GetComponent<AudioSource>().Play();
            }
            if (rng == 1)
            {
                this.GetComponent<AudioSource>().clip = audio1;
                this.GetComponent<AudioSource>().Play();
            }
            if (rng == 2)
            {
                this.GetComponent<AudioSource>().clip = audio2;
                this.GetComponent<AudioSource>().Play();
            }
            if (rng == 3)
            {
                this.GetComponent<AudioSource>().clip = audio3;
                this.GetComponent<AudioSource>().Play();
            }
        }

    }
}
