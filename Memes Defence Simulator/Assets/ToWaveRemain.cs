using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToWaveRemain : MonoBehaviour
{
    public TextMeshProUGUI TextForDelay;
    private float delay;
    public GameObject toWaveMain;
    public GameObject wave1;


    private void Start()
    {
        
    }
    private void FixedUpdate()
    {

        delay = wave1.GetComponent<Wave>().toWave;
        TextForDelay.text = "До волны" +
            "" + delay.ToString("F0");
        if (delay <= 0)
        {
            toWaveMain.SetActive(false);
        }
    }
}
