using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset _inkJSON;

    private bool _isPlayerEnter;

    private DialogueController _dialogueController;
    private DialogueWindow _dialogueWindow;

    private void Start()
    {
        _isPlayerEnter = false;

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
            _dialogueController.EnterDialogueMode(_inkJSON);
        }

    }
    private void OnTriggerEnter(Collider collider)
    {
        GameObject obj = collider.gameObject;

        if (obj.GetComponent<CharacterController>() != null)
        {
            _isPlayerEnter = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        GameObject obj = collider.gameObject;

        if (obj.GetComponent<CharacterController>() != null)
        {
            _isPlayerEnter = false;
        }
    }
}
