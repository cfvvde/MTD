using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using TMPro;
using System;

public class MenyStart : MonoBehaviour
{
    public GameObject HP_ovrlay;
    public GameObject guidispl;
    public GameObject wave1Test;
    public GameObject toWave;

    void Start()
    {
        toWave.SetActive(false);
        HP_ovrlay.SetActive(false);
        guidispl.SetActive(false);
    }
    bool whyTheFuckThisRunsTwice = true;
    public void ButtonPressed()
    {
        HP_ovrlay.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        guidispl.SetActive(true);

        if (wave1Test == null || !whyTheFuckThisRunsTwice)
        {
            return;
        }
        whyTheFuckThisRunsTwice = false;
        
    }

}
