using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;
    

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];
    }

    
   private void Update()
   {
       


       if (Vector3.Distance(transform.position, target.position) <= 1f)
       {
           Debug.Log("Hit CheckPoint");
           getNextWayPoint();
       }

       enemy.speed = enemy.startSpeed;
   }

   void getNextWayPoint()
   {
       if (wavepointIndex >= Waypoints.points.Length - 1)
       {
           EndPath();
           return;
       }


       wavepointIndex++;
       target = Waypoints.points[wavepointIndex];
   }



    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(this.gameObject);
    }
}
