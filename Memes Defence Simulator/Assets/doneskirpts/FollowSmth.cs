using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSmth : MonoBehaviour
{
    public Transform target;
    public int speed = 10;

    
    void Update()
    {
        
        if (EnemyScript.MobHP > 0)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        }
        
    }
}
