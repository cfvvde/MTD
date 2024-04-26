using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class foundItems : MonoBehaviour
{

    public GameObject itemFindEntety;
    public static bool foundMarksman;
    public Dialog dialog;
    private bool inRange = false;

    private void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;

        }
    }
    public void OnTriggerStay(Collider col)
    {

        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            itemFindEntety.SetActive(false);
            foundMarksman = true;
            TriggerDialog();
        }


    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }
}
