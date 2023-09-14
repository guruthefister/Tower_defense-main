    using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform enemy2Prefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;

    public Text waveCountdownText;
    public Text Rounds;

    private int waveIndex = 0;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = String.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        Rounds.text = "Wave = " + (waveIndex).ToString();
        PlayerStats.Rounds++;
        Transform prefab;
        for (int i = 1; i < waveIndex+1; i++) {
            prefab = enemyPrefab;
            if (i % 3 == 0)
            {
                prefab = enemy2Prefab;
            }
            SpawnEnemy(prefab);
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy(Transform enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}
