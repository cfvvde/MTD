using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatplayer : MonoBehaviour
{
    public Transform cameraa;

    void LateUpdate()
    {
        transform.LookAt(cameraa);
    }
}
