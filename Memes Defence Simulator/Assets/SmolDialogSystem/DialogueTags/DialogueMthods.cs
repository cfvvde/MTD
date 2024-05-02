using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMthods : MonoBehaviour
{
    public GameObject dialog;

    void Delay()
    {
        dialog.SetActive(false);
    }

    public void ExitForGame()
    {
        var Dialog = GetComponent<DialogueWindow>();
        Invoke("Delay", 2);
        Cursor.lockState = CursorLockMode.Locked;
        Dialog.IsPlaying = false;

    }
    public void EndDialog()
    {
        var Dialog = GetComponent<DialogueWindow>();
        Invoke("Delay", 2);
        Cursor.lockState = CursorLockMode.Locked;
        Dialog.IsPlaying = false;
    }
    public void PRINT1()
    {
        Debug.Log("1");
    }

}
