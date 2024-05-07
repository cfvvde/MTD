using Ink.Parsed;
using Ink.Runtime;
using Ink.UnityIntegration;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(DialogueWindow), typeof(DialogueTag))]
public class DialogueController : MonoBehaviour
{
    private DialogueWindow _dialogueWindow;
    private DialogueTag _dialogueTag;
    public GameObject Player;
    public Ink.Runtime.Story CurrentStory { get; private set; }
    private Coroutine _displayLineCoroutine;

    private void Awake()
    {
        _dialogueTag = GetComponent<DialogueTag>();
        _dialogueWindow = GetComponent<DialogueWindow>();

        _dialogueTag.Init();
        _dialogueWindow.Init();
    }

    private void Start()
    {
        _dialogueWindow.SetActive(false);
    }

    private void Update()
    {
        if (_dialogueWindow.IsStatusAnswer == true || _dialogueWindow.IsPlaying == false || _dialogueWindow.CanContinueToNextLine == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ContinueStory();
        }
    }
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        
        CurrentStory = new Ink.Runtime.Story(inkJSON.text);
        
        _dialogueWindow.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Player.GetComponentInChildren<mousemove>().enabled = false;
        ContinueStory();
    }

    public IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(_dialogueWindow.CoolDownNewLetter);

        _dialogueWindow.SetActive(false);
        _dialogueWindow.ClearText();
    }

    private void ContinueStory()
    {
        if (CurrentStory.canContinue == false)
        {
            StopCoroutine(ExitDialogueMode());

            return;
        }

        if (_displayLineCoroutine != null)
        {
            StopCoroutine(_displayLineCoroutine);
        }

        _displayLineCoroutine = StartCoroutine(_dialogueWindow.DisplayLine(CurrentStory));

        try
        {
            _dialogueTag.HandleTags(CurrentStory.currentTags);

        }
        catch (ArgumentException ex)
        {
            Debug.LogError(ex.Message);
        }


    }

    public void MakeChoice(int choiceIndex)
    {
        _dialogueWindow.MakeChoice();

        CurrentStory.ChooseChoiceIndex(choiceIndex);

        ContinueStory();

    }
}
