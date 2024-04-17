using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class FindItem : MonoBehaviour
{

    public GameObject itemFindEntety;
    public static bool PistolFind;
    public Dialog dialog;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);

    }
    public void OnTriggerStay()
    {
        
        if (Input.GetKey(KeyCode.Z))
        { 
            itemFindEntety.SetActive(false);
            PistolFind = true;
            TriggerDialog();
            
        }
        
    }
}
