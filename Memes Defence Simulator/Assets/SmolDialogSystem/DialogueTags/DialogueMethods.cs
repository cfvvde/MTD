
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMethods : MonoBehaviour
{
    public GameObject dialog;
    public GameObject picture;
    public GameObject Player;

    public static bool talkedtoprorok = false;
    public static bool foundMarksman = false;

    public GameObject Pistol;
    public Texture Prorok1;
    public RawImage Prorok2;
    public RawImage Prorok3;
    public RawImage Straj1;
    public RawImage Straj2;
    public RawImage Straj3;
    public Texture Author1;
    public RawImage Author2;
    public RawImage Author3;
    void Delay()
    {
        dialog.SetActive(false);
        picture.SetActive(false);
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
    public void DeletPistol()
    {
        Pistol.SetActive(false);
        foundMarksman = true;
    }
    public void EnableP()
    {
        picture.SetActive(true);
    }
    public void DisableP()
    {
        picture.SetActive(false);
    }
    public void SetPToProrok1()
    {
        picture.SetActive(true);
        picture.GetComponent<RawImage>().texture = Prorok1;
    }
    public void SetPToAuthor1()
    {
        picture.SetActive(true);
        picture.GetComponent <RawImage>().texture = Author1;       
    }

}
