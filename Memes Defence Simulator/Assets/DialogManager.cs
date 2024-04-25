using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogText;
    public GameObject faceSprite;

    public Animator animator;



    private Queue<string> sentances;
    private Queue<Texture> imges;
    void Start()
    {
        imges = new Queue<Texture>();
        sentances = new Queue<string>();

    }

    public void StartDialog(Dialog dialog)
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        animator.SetBool("IsONe", true);


        nameText.text = dialog.name;



        sentances.Clear();

        foreach (string sentence in dialog.sentances)
        {
            sentances.Enqueue(sentence);

        }
        foreach (Texture image in dialog.img)
        {
            imges.Enqueue(image);
        }


        DisplayNextSentance();

    }

    public void DisplayNextSentance()
    {




        if (sentances.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentances.Dequeue();
        Texture image = imges.Dequeue();
        faceSprite.GetComponent<RawImage>().texture = image;
        StartCoroutine(TypeSentence(sentence));


    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }
    public void EndDialog()
    {
        animator.SetBool("IsONe", false);
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }
}
