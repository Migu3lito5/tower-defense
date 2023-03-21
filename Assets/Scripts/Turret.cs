using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;
    private Enemy targetEnemy;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity Setup Fields")]

    public Transform Head;
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public int damageOverTime = 50;
    public float slowPercentage = .5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if(useLaser)
            {
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;  
                } 
            }

            return;
        }
            

       

        LookTarget();

        if(useLaser)
        {
            Laser();
        } else
        {
            if (fireCountDown <= 0f)
            {
                Shoot();
                fireCountDown = 1f / fireRate;
            }
            fireCountDown -= Time.deltaTime;

        }        
    }

    void Laser()
    {

        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPercentage);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }

    void LookTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(Head.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        Head.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        } 

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        } else
        {
            target = null;
        }
    }

    void Shoot () { 
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
       

        if(bullet != null)
        {
            bullet.Seek(target);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
