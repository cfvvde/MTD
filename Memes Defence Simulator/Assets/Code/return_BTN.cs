using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class return_BTN : MonoBehaviour
{
    public GameObject returnBTn;
    public GameObject help_img;
    public GameObject mem;
    public GameObject camer;
    public GameObject menu_startBTN;
    public GameObject menu_background;
    public GameObject menu_settings;
    public GameObject menu_help;
    void Start()
    {
        returnBTn.SetActive(false);

    }
    public void ButtonPressedReturn()
    {

        help_img.SetActive(false);
        mem.SetActive(false);
        camer.SetActive(false);
        returnBTn.SetActive(false);
        menu_help.SetActive(true);
        menu_background.SetActive(true);
        menu_startBTN.SetActive(true);
        menu_settings.SetActive(true);
    }

}
