using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent naveshag;
    [SerializeField]
    private Transform player;
    void Start()
    {
        
    }

    void Update()
    {
        naveshag.SetDestination(player.position);
    }
}
