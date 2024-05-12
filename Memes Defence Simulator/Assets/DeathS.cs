using System.Diagnostics.Tracing;
using UnityEngine;

public class DeathS : MonoBehaviour
{

    [SerializeField] private TextAsset _inkJSON1;

    private DialogueController _dialogueController;
    private DialogueWindow _dialogueWindow;

    private void Start()
    {

        _dialogueController = FindObjectOfType<DialogueController>();
        _dialogueWindow = FindObjectOfType<DialogueWindow>();

    }

    public void Death()
    {
        _dialogueController.EnterDialogueMode(_inkJSON1);

    }
}

