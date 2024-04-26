using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform player;
    private int health;
    public GameObject core;


    string targetTag = "Player";

    private void Awake()
    {
        Start();
    }

    void Start()
    {
        if (player == null)
        {
            GameObject objWithTag = GameObject.FindWithTag(targetTag);
            if (objWithTag != null)
            {
                player = objWithTag.transform;
                //Debug.Log("Target transform set to " + objWithTag.name + "'s transform.");
            }
            else
            {
                Debug.LogError("No object found with tag: " + targetTag);
            }
        }
        if (navMeshAgent == null)
            if (GetComponent<NavMeshAgent>() != null)
                navMeshAgent = GetComponent<NavMeshAgent>();
        assignCore();
    }

    public void assignCore()
    {
        foreach (Transform childTransform in transform)
        {
            GameObject childGameObject = childTransform.gameObject;
            // Do something with 'childGameObject'

            if (childGameObject.name == "core")
            {
                core = childGameObject;
            }
        }
    }

    void Update()
    {
        if (core != null)
        {
            health = core.GetComponent<EnemyScript>().MobHP;
        }
        else
        {
            assignCore();
            return;
        }

        if (navMeshAgent.isOnNavMesh)
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
