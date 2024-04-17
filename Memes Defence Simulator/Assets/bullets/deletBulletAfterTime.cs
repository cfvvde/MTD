using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletBulletAfterTime : MonoBehaviour
{

    public int time = 10000;
    public GameObject bullet;
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        Destroy(bullet);
    }
    void FixedUpdate()
    {
        
        if (time > 0)
        {
            time = time - 1;
        }
        else
        {
            Destroy(bullet);
        }
    }
}
