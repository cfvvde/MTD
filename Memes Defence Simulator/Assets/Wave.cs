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

    public IEnumerator call()
    {

        yield return new WaitForSeconds(5f);

        for (int i = 0; i < enemiesID.Count; i++)
        {
            GameObject enemyToSpawn = enemObj[enemiesID[i]];
            int rSpawn = new System.Random().Next(spawnPoints.Count); // Corrected spawn point selection

            // Spawn the enemy
            Instantiate(enemyToSpawn, spawnPoints[rSpawn].transform.position, spawnPoints[rSpawn].transform.rotation);

            // Yield control for the specified delay
            yield return new WaitForSeconds(delays[i]);
        }
    }
}
