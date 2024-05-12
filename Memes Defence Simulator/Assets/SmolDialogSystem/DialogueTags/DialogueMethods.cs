
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMethods : MonoBehaviour
{
    public GameObject GUI1;
    public GameObject GUI2;
    public GameObject GUI3;
    public GameObject GUI4;
    public GameObject GUI5;
    public GameObject GUI6;
    public GameObject GUI7;
    public GameObject GUI8;
    public GameObject GUI9;

    public GameObject dialog;
    public GameObject Player;

    public GameObject Wave1;
    public GameObject Wave2;
    public GameObject Wave3;
    public GameObject Wave4;
    public GameObject Wave5;

    public static bool talkedtoprorok = false;
    public static int PashalkiCount = 0;
    public static int OnWave = 0;

    public static bool foundMarksman = false;
    public static bool foundMedK = false;
    public static bool foundBulb = false;
    public static bool foundKnife = false;
    public static bool haveSword = false;
    public static bool haveAK = false;

    public GameObject Pistol;
    public GameObject MedK;
    public GameObject Bulb;

    void Delay()
    {
        dialog.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Player.GetComponentInChildren<mousemove>().enabled = true;
        Player.GetComponent<CharacterController>().enabled = true;
    }
    public void EndDialogTime5()
    {
        var Dialog = GetComponent<DialogueWindow>();
        Invoke("Delay", 5);
        Dialog.IsPlaying = false;
        
    }
    public void EndDialogTime3()
    {
        var Dialog = GetComponent<DialogueWindow>();
        Invoke("Delay", 3.5f);

        Dialog.IsPlaying = false;
    }
    public void TalkedToProrok()
    {
        talkedtoprorok=true;
    }
    public void GiveSwordAndStartWave()
    {
        EndDialogTime5();
        haveSword=true;
        GUI1.SetActive(true);
        Wave1.SetActive(true);

        Wave script = Wave1.GetComponent<Wave>();



        if (script != null)
        {
            script.StartCoroutine(script.call());
        }
        else
        {
            Debug.LogError($"Could not find Wave component on GameObject named '{Wave1.name}'");
        }
        OnWave = 1;
    }
    public void StartWave2()
    {
        EndDialogTime5();
        haveAK = true;
        GUI3.SetActive(true);
        Wave2.SetActive(true);

        Wave script = Wave2.GetComponent<Wave>();



        if (script != null)
        {
            script.StartCoroutine(script.call());
        }
        else
        {
            Debug.LogError($"Could not find Wave component on GameObject named '{Wave2.name}'");
        }
        OnWave = 2;
    }
    public void StartWave3()
    {
        Wave3.SetActive(true);

        Wave script = Wave3.GetComponent<Wave>();



        if (script != null)
        {
            script.StartCoroutine(script.call());
        }
        else
        {
            Debug.LogError($"Could not find Wave component on GameObject named '{Wave3.name}'");
        }
        OnWave = 3;
    }
    public void StartWave4()
    {
        Wave4.SetActive(true);

        Wave script = Wave4.GetComponent<Wave>();



        if (script != null)
        {
            script.StartCoroutine(script.call());
        }
        else
        {
            Debug.LogError($"Could not find Wave component on GameObject named '{Wave4.name}'");
        }
        OnWave = 4;
    }
    public void StartWave5() 
    {
        Wave5.SetActive(true);

        Wave script = Wave5.GetComponent<Wave>();



        if (script != null)
        {
            script.StartCoroutine(script.call());
        }
        else
        {
            Debug.LogError($"Could not find Wave component on GameObject named '{Wave5.name}'");
        }
        OnWave = 5;
    }
    public void ExitForGame()
    {
        var Dialog = GetComponent<DialogueWindow>();
        Invoke("Delay", 2);

        Dialog.IsPlaying = false;

    }
    public void EndDialog()
    {
        var Dialog = GetComponent<DialogueWindow>();
        Invoke("Delay", 2);

        Dialog.IsPlaying = false;

    }
    public void PRINT1()
    {
        Debug.Log("1");
    }
    public void DeletPistol()
    {

        Pistol.SetActive(false);
        foundMarksman = true;
        GUI8.SetActive(true);
        PashalkiCount++;
    }

    public void DeletMedK()
    {
        MedK.SetActive(false);
        foundMedK = true;
        GUI7.SetActive(true);
        PashalkiCount++;
    }
    public void DeletBulb()
    {
        Bulb.SetActive(false);
        foundBulb = true;
        GUI6.SetActive(true);
        PashalkiCount++;
    }



    public void TakeK()
    {
        var knf = GameObject.FindGameObjectsWithTag("KNIFE");
        for(int i = 0; i<knf.Length; i++)
        {
            Destroy(knf[i]);
        }
        foundKnife = true;
        GUI9.SetActive(true);
        PashalkiCount++;
    }



}
