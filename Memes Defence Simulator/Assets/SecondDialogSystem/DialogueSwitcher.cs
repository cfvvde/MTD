using UnityEngine;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Dialogue
{

    public class DialogueSwitcher : MonoBehaviour
    {
        [SerializeField] private string[] _disableTags;
        private DialogueStory _dialogueStory;

        private void Start()
        {
            _dialogueStory = FindObjectOfType<DialogueStory>(true);
            _dialogueStory.ChangedStory += Disable;

        }
        private async void Disable(DialogueStory.Story story)
        {
            if(_disableTags.All(disableTag => story.Tag != disableTag)) return;
            await Task.Delay(2000);
            _dialogueStory.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

}