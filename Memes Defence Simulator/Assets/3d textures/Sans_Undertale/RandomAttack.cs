using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAttack : MonoBehaviour
{
    public GameObject attack1;
    public GameObject attack2;
    public GameObject attack3;  
    public GameObject attack1Explonation;
    public GameObject player;
    private int rng;
    private float currentTime = 0;
    public float timeDiff = 3;

    private int prng = 0;
    private Transform playerPos;
    private Vector3 pPos;

    private void FixedUpdate()
    {
        playerPos = player.GetComponent<Transform>();
        pPos = playerPos.position;
        if (currentTime + timeDiff <= Time.time)
        {
            currentTime = Time.time;
            rng = new System.Random().Next(4);

            if (rng == prng)
                return;
            switch (rng)
            {
                //case 0:
                    

               // case 1:
                    

               // case 2:

               // case 3:
                    
            }
            prng = rng;
        }
    }
}
