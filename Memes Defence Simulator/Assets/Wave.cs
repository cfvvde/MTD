using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public List<int> enemiesID = new() { 0 };
    public List<float> delays = new() { 1 };
    public List<GameObject> enemObj = new();
    public List<GameObject> spawnPoints = new();

    public Wave()
    {

    }

    public void Call()
    {
        for (int i = 0; i < enemiesID.Count; i++)
        {
            GameObject enemyToSpawn = enemObj[enemiesID[i]];
            int rSpawn = new System.Random().Next(spawnPoints.Count);

            Debug.Log("spawning enemy {0}", enemyToSpawn);
            new WaitForSecondsRealtime(delays[i]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Start the coroutine we define below named Sleep.
        StartCoroutine(Sleep(5));
    }

    IEnumerator Sleep(float time)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
