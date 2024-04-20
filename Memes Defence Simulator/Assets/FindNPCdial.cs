using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNPCdial : MonoBehaviour
{
    public GameObject itemFindEntety;
    public GameObject dialog;
    private bool inrange = false;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            inrange = true;

        }
    }
    public void OnTriggerStay(Collider col)
    {

        if (col.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            itemFindEntety.SetActive(false);
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
    private void TriggerDialog()
    {
        dialog.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

    }
}
