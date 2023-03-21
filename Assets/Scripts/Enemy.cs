using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    
    [HideInInspector]
    public float speed;

    public float healt = 100;

    public GameObject deathEffect; 

    public int value = 50;

    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        healt -= amount;

        if(healt <= 0)
        {
            Die();
        }
    }

    public void Slow(float percentage)
    {
        speed = startSpeed * (1f - percentage);
    }

    void Die()
    {
        PlayerStats.Money += value;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect,3f);
        
        Destroy(gameObject);
    }


   


}
