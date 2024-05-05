using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooakAtForAt : MonoBehaviour
{
    public Transform cameraa;

    string targetTag = "Player";


    private void Awake()
    {
        if (cameraa == null)
        {
            GameObject objWithTag = GameObject.FindWithTag(targetTag);
            if (objWithTag != null)
            {
                cameraa = objWithTag.transform;
                //Debug.Log("Target transform set to " + objWithTag.name + "'s transform.");
            }
            else
            {
                Debug.LogError("No object found with tag: " + targetTag);
            }
        }
    }
    void LateUpdate()
    {

        transform.LookAt(cameraa, Vector3.up);
    }
}