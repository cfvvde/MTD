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
            if (Input.GetKey(KeyCode.Alpha1) && DialogueMethods.haveSword == true)
            {
                select(weapons[0]);
            }
            if (Input.GetKey(KeyCode.Alpha2) && weapon.AnimationCoolDown == false)
            {
                select(weapons[1]);
            }
            if (Input.GetKey(KeyCode.Alpha8) && DialogueMethods.foundMarksman == true && weapon.AnimationCoolDown == false)
            {
                select(weapons[7]);
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
