using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guiWeponChange : MonoBehaviour
{
    public static GameObject weapon1;
    public static GameObject weapon2;
    public static GameObject weapon3;
    public static GameObject weapon4;
    public static GameObject weapon5;
    public static GameObject weapon6;
    public static GameObject weapon7;
    public static GameObject weapon8;
    public static GameObject weapon9;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            //weapon1.SetActive(true);
            //weapon2.SetActive(false);
            //
            //weapon8.SetActive(false);
            Select(weapon1);

        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true);

            weapon8.SetActive(false);

        }
        if (Input.GetKey(KeyCode.Alpha8) && foundItems.foundMarksman == true)
        {
            weapon1.SetActive(false);
            weapon2.SetActive(false);

            weapon8.SetActive(true);

        }

    }

    private void Select(GameObject W)
    {

        if (W == weapon1)
        {
            W.SetActive(!W.activeInHierarchy);
            weapon2.SetActive(false);
            weapon8.SetActive(false);
        }
        if (W == weapon2)
        {
            W.SetActive(!W.activeInHierarchy);
            weapon1.SetActive(false);
            weapon8.SetActive(false);
        }
        if (W == weapon8)
        {
            W.SetActive(!W.activeInHierarchy);
            weapon1.SetActive(false);
            weapon2.SetActive(false);
        }
    }
}
