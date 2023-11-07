﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> WaveConfigs;
    WaveConfigSO currentWave;

    [SerializeField]  float timeBetweenWaves = 5f; 

    int enemyIndex;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    // Get ra WaveConfigSO hiện tại
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        foreach (WaveConfigSO wave in WaveConfigs)
        {
            currentWave = wave;

            for (enemyIndex = 0; enemyIndex < currentWave.GetEnemyCount(); enemyIndex++)
            {
                Instantiate(currentWave.GetEnemyPrefab(enemyIndex),
                              currentWave.GetStartingWaypoint().position,
                              Quaternion.identity,
                              transform
                              );

                yield return new WaitForSecondsRealtime(currentWave.GetRandomSpawnTime());

            }

            yield return new WaitForSecondsRealtime(timeBetweenWaves);
        }

        
    }



}