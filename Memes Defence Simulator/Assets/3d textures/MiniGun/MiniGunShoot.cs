using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MiniGunShoot : MonoBehaviour
{
    public GameObject SpawnB;
    public GameObject Bullet;
    private bool Firing;
    public int time = 6;
    private int timeN;
    public GameObject anim;
    private void Start()
    {
        var array = new int[] { 1, -1};

        array = new int[] { 1, -1 };
    }
    private void Update()
    {
        var Pos = SpawnB.transform.position;
        var Rot = SpawnB.transform.rotation;
        if (Firing == true)
        {
            if (timeN >= time)
            {
                var randomFY = Random.Range(-100, 100);
                var randomFX = Random.Range(-100, 100);
                Instantiate(Bullet, Pos, Rot).GetComponent<Rigidbody>().AddRelativeForce(randomFX * 10, randomFY * 10, 15000f);
                timeN= 0;
            }
            else
            {
                timeN++;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<AudioSource>().enabled = true;
            anim.GetComponent<Animator>().enabled = true;
            Firing = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Firing = false;
            anim.GetComponent<Animator>().enabled = false;
            this.GetComponent<AudioSource>().enabled = false;
        }
    }


}

