using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guiWeponChange : MonoBehaviour
{
    public GameObject[] weapons = new GameObject[9];

    private float currTime = 0;
    public float deadTimeSeconds = 0.5f; // time that you cant switch weapons for
                                         // after switching to another weapon

    private void FixedUpdate()
    {
        if (currTime + deadTimeSeconds <= Time.time)
        {
            if (Input.GetKey(KeyCode.Alpha1) && DialogueMethods.haveSword == true && AKshoot.animeInM == false)
            {
                select(weapons[0]);
            }
            if (Input.GetKey(KeyCode.Alpha2) && weapon.AnimationCoolDown == false && AKshoot.animeInM == false)
            {
                select(weapons[1]);
            }
            if (Input.GetKey(KeyCode.Alpha3) && weapon.AnimationCoolDown == false && AKshoot.animeInM == false && DialogueMethods.haveAK == true)
            {
                weapons[2].GetComponent<AKshoot>().SetNormal();
                select(weapons[2]);
            }
            if (Input.GetKey(KeyCode.Alpha4) && weapon.AnimationCoolDown == false && DialogueMethods.haveMiniGun == true && AKshoot.animeInM == false)
            {
                select(weapons[3]);
            }
            if (Input.GetKey(KeyCode.Alpha6) && DialogueMethods.foundBulb == true && weapon.AnimationCoolDown == false && AKshoot.animeInM == false)
            {
                select(weapons[5]);
            }
            if (Input.GetKey(KeyCode.Alpha7) && DialogueMethods.foundMedK == true && weapon.AnimationCoolDown == false && AKshoot.animeInM == false) 
            {
                select(weapons[6]);
            }
            if (Input.GetKey(KeyCode.Alpha8) && DialogueMethods.foundMarksman == true && weapon.AnimationCoolDown == false && AKshoot.animeInM == false)
            {
                select(weapons[7]);
            }
            if (Input.GetKey(KeyCode.Alpha9) && DialogueMethods.foundKnife == true && weapon.AnimationCoolDown == false && AKshoot.animeInM == false)
            {
                select(weapons[8]);
            }

        }

    }

    private void select(GameObject toSelect)
    {
        currTime = Time.time;
        foreach (GameObject wpn in weapons)
        {
            if (wpn == null)
                continue;

            if (wpn == toSelect)
            {
                wpn.SetActive(!wpn.activeInHierarchy);
            }
            else
            {
                wpn.SetActive(false);
            }
        }
    }
}
