using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToWaveRemain : MonoBehaviour
{
    public TextMeshProUGUI TextForDelay;
    private float delay;
    public GameObject toWaveMain;


    private void Start()
    {
        toWaveMain.SetActive(false);
    }
    private void FixedUpdate()
    {
        var wave1 = GameObject.FindGameObjectWithTag("WAVE");
        if (wave1 != null)
        {
            delay = wave1.GetComponent<Wave>().toWave;
            TextForDelay.text = "До волны  " +
                "" + delay.ToString("F0");
            if (delay <= 0)
            {
                toWaveMain.SetActive(false);
            }
            else
            {
                toWaveMain.SetActive(true);
            }
        }
    }
}
