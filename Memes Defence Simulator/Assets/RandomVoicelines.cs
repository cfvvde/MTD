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
    private float currentTime = 0;
    public float timeDiff = 3;
    private int prng = 0;
    private void FixedUpdate()
    {
        if (currentTime + timeDiff <= Time.time)
        {
            currentTime = Time.time;
            this.GetComponent<AudioSource>().enabled = true;
            rng = new System.Random().Next(4);
            if (rng != prng)
                switch (rng)
                {
                    case 0:
                        GetComponent<AudioSource>().clip = audio0;
                        break;

                    case 1:
                        GetComponent<AudioSource>().clip = audio1;
                        break;

                    case 2:
                        GetComponent<AudioSource>().clip = audio2;
                        break;

                    case 3:
                        GetComponent<AudioSource>().clip = audio3;
                        break;
                }
            else
                if (rng - 1 < 0)
                    rng = 4;
                else 
                    rng = rng - 1;
            prng = rng;
            this.GetComponent<AudioSource>().Play();
        }
    }
}
