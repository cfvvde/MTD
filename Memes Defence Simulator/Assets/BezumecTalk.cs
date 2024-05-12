using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezumecTalk : MonoBehaviour
{
    public GameObject PressTo;

    [SerializeField] private TextAsset _inkJSON1;
    [SerializeField] private TextAsset _inkJSON2;
    [SerializeField] private TextAsset Paschalk1;
    [SerializeField] private TextAsset Paschalk2;
    [SerializeField] private TextAsset Paschalk3;
    [SerializeField] private TextAsset Paschalk4;
    [SerializeField] private TextAsset TalkedAbout;
    [SerializeField] private TextAsset TalkedAboutDark;

    private bool Talked = false;
    private bool Talked0 = false;
    private bool Talked1 = false;
    private bool Talked2 = false;
    private bool Talked3 = false;
    private bool Talked4 = false;

    private bool _isPlayerEnter;

    private DialogueController _dialogueController;
    private DialogueWindow _dialogueWindow;

    private void Start()
    {
        _isPlayerEnter = false;
        PressTo.SetActive(false);
        _dialogueController = FindObjectOfType<DialogueController>();
        _dialogueWindow = FindObjectOfType<DialogueWindow>();

    }

    public void Update()
    {
        if (_dialogueWindow.IsPlaying == true || _isPlayerEnter == false)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (DialogueMethods.talkedtoprorok == false)
            {
                _dialogueController.EnterDialogueMode(_inkJSON1);
            }
            else
            {
                if (Talked == false)
                {
                    _dialogueController.EnterDialogueMode(_inkJSON2);
                    Talked = true;
                }
                else
                {
                    if (DialogueMethods.PashalkiCount == 0)
                    {
                        _dialogueController.EnterDialogueMode(TalkedAboutDark);   
                    }
                    if (DialogueMethods.PashalkiCount == 1)
                    {
                        if (Talked1 == false)
                        {
                            Talked1 = true;
                            _dialogueController.EnterDialogueMode(Paschalk1);
                        }
                        else
                        {
                            _dialogueController.EnterDialogueMode(TalkedAbout);
                        }
                    }
                    if (DialogueMethods.PashalkiCount == 2)
                    {
                        if (Talked2 == false)
                        {
                            Talked2 = true;
                            _dialogueController.EnterDialogueMode(Paschalk2);
                        }
                        else
                        {
                            _dialogueController.EnterDialogueMode(TalkedAbout);
                        }
                    }
                    if (DialogueMethods.PashalkiCount == 3)
                    {
                        if (Talked3 == false)
                        {
                            Talked3 = true;
                            _dialogueController.EnterDialogueMode(Paschalk3);
                        }
                        else
                        {
                            _dialogueController.EnterDialogueMode(TalkedAbout);
                        }
                    }
                    if (DialogueMethods.PashalkiCount == 4)
                    {
                        
                        _dialogueController.EnterDialogueMode(Paschalk4);
                        
                        
                    }
                }
            }
        }

    }
    private void OnTriggerEnter(Collider collider)
    {
        GameObject obj = collider.gameObject;

        if (obj.GetComponent<CharacterController>() != null)
        {
            _isPlayerEnter = true;
            PressTo.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        GameObject obj = collider.gameObject;

        if (obj.GetComponent<CharacterController>() != null)
        {
            _isPlayerEnter = false;
            PressTo.SetActive(false);
        }

    }
}