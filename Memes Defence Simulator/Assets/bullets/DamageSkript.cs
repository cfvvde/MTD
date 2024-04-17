using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSkript : MonoBehaviour
{
    public int DamageAmount = 20;
    public void OnTriggerEnter(Collider other)

    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyScript>().TakeDamage(DamageAmount);
        }

    }
}
