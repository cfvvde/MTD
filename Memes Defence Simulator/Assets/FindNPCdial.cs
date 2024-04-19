using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNPCdial : MonoBehaviour
{
    public GameObject itemFindEntety;
    public GameObject dialog;

    public void OnTriggerStay()
    {

        if (Input.GetKey(KeyCode.Z))
        {
            itemFindEntety.SetActive(false);
            TriggerDialog();

        }


    }
    public void TriggerDialog()
    {
        dialog.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

    }
}
