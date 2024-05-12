using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKshoot : MonoBehaviour
{
    public GameObject SpawnB;
    public GameObject Bullet;
    public GameObject ReloadingSound;
    public GameObject ReloadMagAn;
    public int reload = 100;
    public int bulletsCount = 30;
    public static bool nowReload;
    private int bullets = 30;
    private int reloadingT = 0;

    public static bool animeInM = false;

    public void SetNormal()
    {
        nowReload = true;
        bullets = bulletsCount;
        reloadingT = 0;
        reload = 180;
    }
    void Update()
    {

        var Pos = SpawnB.transform.position;
        var Rot = SpawnB.transform.rotation;
        if (nowReload == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (bullets > 0)
                {
                    Instantiate(Bullet, Pos, Rot).GetComponent<Rigidbody>().AddRelativeForce(0, 0, 15000f);
                    reloadingT = 0;
                    bullets -= 1;
                }
                else
                {
                    animeInM = true;
                    nowReload = true;
                    bullets = bulletsCount;
                    ReloadingSound.GetComponent<AudioSource>().Play();
                    ReloadMagAn.GetComponent<Animator>().Play("Reload");

                }
            }
        }
        else
        {
            if (reloadingT>=reload)
            {
                nowReload = false;
                animeInM = false;
                reloadingT = 0;
                
            }
            else
            {
                animeInM = true;
                reloadingT++;
            }
        }
    }

}
