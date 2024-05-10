using System.Diagnostics.Tracing;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public GameObject PressTo;

    [SerializeField] private TextAsset _inkJSON1;
    [SerializeField] private TextAsset _inkJSON2;

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
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (DialogueMethods.talkedtoprorok == false)
            {
                _dialogueController.EnterDialogueMode(_inkJSON1); 
            }
            else
            {
                _dialogueController.EnterDialogueMode(_inkJSON2);
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
