using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSet: MonoBehaviour
{
    public GameObject returnBTN;
    public GameObject help_img;
    private void Start()
    {
        help_img.SetActive(false);

    }

    public void ButtonPressed()
    {   
        returnBTN.SetActive(true);
        help_img.SetActive(true);
    }

}
