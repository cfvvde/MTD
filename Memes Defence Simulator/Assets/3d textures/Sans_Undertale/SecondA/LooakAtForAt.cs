using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooakAtForAt : MonoBehaviour
{
    public Transform cameraa;

    string targetTag = "Player";

    void LateUpdate()
    {
        GameObject objWithTag = GameObject.FindWithTag(targetTag);
        cameraa = objWithTag.transform;
        transform.LookAt(cameraa, Vector3.down);
        
    }
}