using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueMthods))]
public class MethodTag : MonoBehaviour, ITag
{
    public void Calling(string value)
    {
        var dialogueMethods = GetComponent<DialogueMthods>();

        var method = dialogueMethods.GetType().GetMethod(value);

        method.Invoke(dialogueMethods, null);
    }
}
