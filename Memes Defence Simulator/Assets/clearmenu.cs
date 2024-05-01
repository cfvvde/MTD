using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearmenu : MonoBehaviour
{
    public GameObject menu_startBTN;
    public GameObject menu_background;
    public GameObject menu_settings;
    public GameObject menu_help;
    

    private void Start()
    {
        menu_background.SetActive(true);
        menu_startBTN.SetActive(true);
        menu_settings.SetActive(true);
        menu_help.SetActive(true);
    }
    public void MenuDisablede()
    {
        menu_help.SetActive(false);
        menu_background.SetActive(false);
        menu_startBTN.SetActive(false);
        menu_settings.SetActive(false);
    }
}
