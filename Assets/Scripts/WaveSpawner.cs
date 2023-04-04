using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public GameManager gameManager;

   // public Transform enemyPrefab;
    public Transform spawnPoint;

    public TextMeshProUGUI waveCountDownText;

    public float timeBetweenWaves = 5.5f;
    private float countDown = 2f;

    private int waveIndex = 0;

    private void Update()
    {

        if (EnemiesAlive > 0) return;
       

        if(countDown <= 0f)
        {
            StartCoroutine(spawnWave());
            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00}", countDown);

    }

    IEnumerator spawnWave()
    {
        Debug.Log("Wave Incoming...");

        
        PlayerStats.Rounds++;
        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for(int i = 0; i < wave.count; i++)
        {
            spawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1 / wave.rate);
        }
         
        waveIndex++;

        if(waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;

        }

    }

    void spawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        
    }

}
