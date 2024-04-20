using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class FindItem : MonoBehaviour
{

    public GameObject itemFindEntety;
    public static bool PistolFind;
    public Dialog dialog;
    private bool inrange = false;

    private void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inrange = true;

        }
    }
    public void OnTriggerStay(Collider col)
    {

        if (inrange == true && Input.GetKeyDown(KeyCode.E))
        {
            itemFindEntety.SetActive(false);
            PistolFind = true;
            TriggerDialog();
        }


    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inrange = false;
        }
    }
}
