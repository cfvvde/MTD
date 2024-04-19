using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

namespace Dialogue
{   
    
    public class DialogueStory : MonoBehaviour
    {   
        [SerializeField] private Story[] _stories;
        private Dictionary<string, Story> _storiesDictionary;
        public event Action<Story> ChangedStory;

        [Serializable]
        public struct Story
        {
            [field: SerializeField] public string Tag {get; private set;}
            [field: SerializeField] public string Text {get; private set;}
            [field: SerializeField] public Answer[] Answer {get; private set;}


        }

        [Serializable]
        public struct Answer
        {
            [field: SerializeField] public string Text {get; private set;}
            [field: SerializeField] public string ReposeText {get; private set;}

        }

        private void Start()
        {
            _storiesDictionary = _stories.ToDictionary(key => key.Tag, element => element);
            ChangeStory(_stories[0].Tag);
        }

        public void ChangeStory(string tag) => ChangedStory?.Invoke(_storiesDictionary[tag]);
    }
}