using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    
    [HideInInspector]
    public float speed;
    public float startHealth = 100;

    public float healt;

    public GameObject deathEffect; 

    public int value = 50;

    [Header("UnityStuff")]
    public Image healthBar;

    private void Start()
    {
        speed = startSpeed;
        healt = startHealth;
    }

    public void TakeDamage(float amount)
    {
        healt -= amount;
        healthBar.fillAmount = healt / startHealth;

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
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }


   


}
