using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straj : MonoBehaviour
{
    public GameObject PressTo;

    [SerializeField] private TextAsset _inkJSON1;
    [SerializeField] private TextAsset _inkJSON2;
    
    [SerializeField] private TextAsset _inkJSONWave1;
    [SerializeField] private TextAsset _inkJSONWave2;
    [SerializeField] private TextAsset _inkJSONWave3;
    [SerializeField] private TextAsset _inkJSONWave4;

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
                if (DialogueMethods.OnWave == 0)
                {
                    _dialogueController.EnterDialogueMode(_inkJSON2);
                }
                if (DialogueMethods.OnWave == 1)
                {
                    _dialogueController.EnterDialogueMode(_inkJSONWave1);
                }
                if (DialogueMethods.OnWave == 2)
                {
                    _dialogueController.EnterDialogueMode(_inkJSONWave2);
                }
                if (DialogueMethods.OnWave == 3)
                {
                    _dialogueController.EnterDialogueMode(_inkJSONWave3);
                }
                if (DialogueMethods.OnWave == 4)
                {
                    _dialogueController.EnterDialogueMode(_inkJSONWave4);
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
