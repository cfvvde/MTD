using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mem_help : MonoBehaviour
{   
    public GameObject camer;
    public GameObject mem;
    public GameObject returnBTN;
    void Start()
    {   
        mem.SetActive(false);
        camer.SetActive(false);
    }
    public void OnButtonPressed()
    {   
        returnBTN.SetActive(true);
        mem.SetActive(true);
        camer.SetActive(true);
    }
}
