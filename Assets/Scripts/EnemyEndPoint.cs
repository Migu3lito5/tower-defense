using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEndPoint : MonoBehaviour
{


   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello");
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(other.gameObject);
    }

}
