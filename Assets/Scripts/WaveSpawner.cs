using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public TextMeshProUGUI waveCountDownText;

    public float timeBetweenWaves = 5.5f;
    private float countDown = 2f;
    private int waveIndex = 0;

    private void Update()
    {
        if(countDown <= 0f)
        {
            StartCoroutine(spawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;
        waveCountDownText.text = Mathf.Round(countDown).ToString();
    }

    IEnumerator spawnWave()
    {
        Debug.Log("Wave Incoming...");

        waveIndex++;

        for(int i = 0; i < waveIndex; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.4F);
        }
    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
