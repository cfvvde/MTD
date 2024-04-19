using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

namespace Dialogue
{
    public class AnswerButtons : MonoBehaviour
    {
        [SerializeField] private Button[] _buttons;
        private TMP_Text[] _buttonsText;
        private string[] _currentReplyTags;
        private DialogueStory _dialogueStory;

        private void Awake()
        {
            _dialogueStory = GetComponent<DialogueStory>();
            _dialogueStory.ChangedStory += ChangeAnswers;

            _buttonsText = new TMP_Text[_buttons.Length];
            _currentReplyTags = new string[_buttons.Length];

            for (int i = 0; i < _buttons.Length; i++)
            {
                int button = i;
                _buttons[i].onClick.AddListener(() => SendAnswer(button));
                _buttonsText[i] = _buttons[i].gameObject.GetComponentInChildren<TMP_Text>();
            }

        }

        private void ChangeAnswers(DialogueStory.Story story)
        {
            for(int i = 0; i < _buttonsText.Length; i++)
            {   
                if (story.Answer.Length <= i)
                {
                    _buttonsText[i].text = null;
                    _buttons[i].interactable = false;
                    continue;
                }
                _buttonsText[i].text = story.Answer[i].Text;
                _currentReplyTags[i] = story.Answer[i].ReposeText;
                _buttons[i].interactable = true;
            }
        }
        private void SendAnswer(int button) => _dialogueStory.ChangeStory(_currentReplyTags[button]);
    }   

}