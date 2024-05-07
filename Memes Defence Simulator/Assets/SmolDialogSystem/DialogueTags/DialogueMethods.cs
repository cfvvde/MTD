using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMethods : MonoBehaviour
{
    public GameObject dialog;
    public GameObject Player;
    public static bool talkedtoprorok = false;
    void Delay()
    {
        dialog.SetActive(false);

    }
    public void EndDialogTime5()
    {
        var Dialog = GetComponent<DialogueWindow>();
        Invoke("Delay", 5);
        Cursor.lockState = CursorLockMode.Locked;
        Dialog.IsPlaying = false;
        Player.GetComponentInChildren<mousemove>().enabled = true;
    }
    public void TalkedToProrok()
    {
        talkedtoprorok=true;
    }
    public void ExitForGame()
    {
        var Dialog = GetComponent<DialogueWindow>();
        Invoke("Delay", 2);
        Cursor.lockState = CursorLockMode.Locked;
        Dialog.IsPlaying = false;
        Player.GetComponentInChildren<mousemove>().enabled = true;
    }
    public void EndDialog()
    {
        var Dialog = GetComponent<DialogueWindow>();
        Invoke("Delay", 2);
        Cursor.lockState = CursorLockMode.Locked;
        Dialog.IsPlaying = false;
        Player.GetComponentInChildren<mousemove>().enabled = true;
    }
    public void PRINT1()
    {
        Debug.Log("1");
    }

}
