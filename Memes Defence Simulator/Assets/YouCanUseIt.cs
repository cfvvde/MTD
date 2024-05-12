using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouCanUseIt : MonoBehaviour
{


    [SerializeField] private TextAsset _inkJSON1;
    private DialogueController _dialogueController;
    private DialogueWindow _dialogueWindow;

    public ScriptableObject script;
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
        this.GetComponent<YouCanUseIt>().enabled = false;

    }
}
