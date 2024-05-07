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
            if (other.GetComponent<EnemyScript>() != null)
            {
                other.GetComponent<EnemyScript>().TakeDamage(DamageAmount);
            }
            else
            {
                other.GetComponent<SpecialEnemySkript>().TakeDamage();
            }
        }

    }
}
