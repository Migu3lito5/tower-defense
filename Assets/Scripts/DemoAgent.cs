using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemoAgent : MonoBehaviour
{
    public Transform destination;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(clickRay, out RaycastHit hitInfo, Mathf.Infinity))
            {
                GetComponent<NavMeshAgent>().SetDestination(hitInfo.point);
                destination.position = hitInfo.point;
            }
        }        
    }
}
