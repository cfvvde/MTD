using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset _inkJSON;
    [SerializeField] private DialogueController _dialogueController;

    public void ChangeField(int value)
    {
        Ink.Runtime.Story story = new Ink.Runtime.Story(_inkJSON.text);

        story.variablesState["nemeField"] = value;

        Debug.Log(story.variablesState["nemeField"]);

        //или

        var currentStory = _dialogueController.CurrentStory;

        currentStory.variablesState["nameField"] = value;

        Debug.Log(currentStory.variablesState["nemeField"]);
    }
}
