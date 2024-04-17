using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guiWeponChange : MonoBehaviour
{
    public GameObject W1;
    public GameObject W2;
    public GameObject W3;
    public GameObject W4;
    public GameObject W5;
    public GameObject W6;
    public GameObject W7;
    public GameObject W8;
    public GameObject W9;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            W1.SetActive(true);
            W2.SetActive(false);

            W8.SetActive(false);

        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            W1.SetActive(false);
            W2.SetActive(true);

            W8.SetActive(false);

        }
        if (Input.GetKey(KeyCode.Alpha8) && FindItem.PistolFind == true)
        {
            W1.SetActive(false);
            W2.SetActive(false);

            W8.SetActive(true);

        }

    }
}
