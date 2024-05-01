using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public List<int> enemiesID = new() { 0 };
    public List<float> delays = new() { 5 };
    public List<GameObject> enemObj = new();
    public List<GameObject> spawnPoints = new();
    public float toWave = 0f;
    public float firstDelay;

    public IEnumerator call()
    {
        toWave = firstDelay;
        for (int h = 0; h < firstDelay; h++)
        {
            toWave = toWave - 1;
            yield return new WaitForSeconds(1);
            
        }

        for (int i = 0; i < enemiesID.Count; i++)
        {
            GameObject enemyToSpawn = enemObj[enemiesID[i]];
            int rSpawn = new System.Random().Next(spawnPoints.Count); // Corrected spawn point selection

            // Spawn the enemy
            Instantiate(enemyToSpawn, spawnPoints[rSpawn].transform.position, spawnPoints[rSpawn].transform.rotation);
            toWave = delays[i];
            // Yield control for the specified delay
            for (int h = 0; h < delays[i]; h++)
            {
                toWave = toWave - 1;
                yield return new WaitForSeconds(1);
                
            }
                
        }
    }
}
