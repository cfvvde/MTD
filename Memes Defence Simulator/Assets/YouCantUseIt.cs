using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouCantUseIt : MonoBehaviour
{


    [SerializeField] private TextAsset _inkJSON1;
    private DialogueController _dialogueController;
    private DialogueWindow _dialogueWindow;

    private void Start()
    {

        _dialogueController = FindObjectOfType<DialogueController>();
        _dialogueWindow = FindObjectOfType<DialogueWindow>();

    }

    public void Update()
    {
        if (_dialogueWindow.IsPlaying == true)
        {
            return;
        }
        if (Input.GetMouseButton(0))
        {

            _dialogueController.EnterDialogueMode(_inkJSON1);

        }

    }

}
