using Ink.Parsed;
using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueChoice : MonoBehaviour
{
    [SerializeField] private GameObject[] _choices;
    private TextMeshProUGUI[] _chocicesText;

    public void Init()
    {
        _chocicesText = new TextMeshProUGUI[_choices.Length];

        ushort index = 0;
        foreach (GameObject choice in _choices)
        {
            _chocicesText[index++] = choice.GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    public bool DisplayChoices(Ink.Runtime.Story story)
    {
        Ink.Runtime.Choice[] currentChoices = story.currentChoices.ToArray();

        if (currentChoices.Length > _choices.Length) 
        {
            throw new ArgumentNullException("Ошибка! Выборов в сценарии больше, чем возможностей выбора");
        }

        HideChoices();

        ushort index = 0;

        foreach (Ink.Runtime.Choice choice in currentChoices)
        {
            _choices[index].SetActive(true);
            _chocicesText[index++].text = choice.text;
        }

        return currentChoices.Length > 0;
    }

    public void HideChoices() 
    {
        foreach (var button in _choices)
        {
            button.SetActive(false);
        }


    }
}
