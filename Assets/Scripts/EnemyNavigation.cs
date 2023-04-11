using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementNavigation : MonoBehaviour
{
    public Transform destination;

    private void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(destination.position);
              
    }
}
