using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using TMPro;

public class MenyStart : MonoBehaviour
{   
    public GameObject HP_ovrlay;
    public GameObject guidispl;

    void Start()
    {
        
        HP_ovrlay.SetActive(false);
        guidispl.SetActive(false);
    }

    public void ButtonPressed()
    {
        HP_ovrlay.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        guidispl.SetActive(true);

    }

}
