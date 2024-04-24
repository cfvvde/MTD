using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public Transform player;

    private int health;

    private GameObject core;
    void Start()
    {
        foreach (Transform childTransform in transform)
        {
            GameObject childGameObject = childTransform.gameObject;
            // Do something with 'childGameObject'
            switch (childGameObject.name)
            {
                case "dummy":
                    core = childGameObject;
                    break;
            }
        }
    }

    void Update()
    {
        health = core.GetComponent<EnemyScript>().MobHP;

        switch (health <= 0)
        {
            case true:
                navMeshAgent.SetDestination(transform.position);
                break;

            case false:
                navMeshAgent.SetDestination(player.position);
                break;
        }
    }
}
