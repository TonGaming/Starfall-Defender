using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] WaveConfigSO currentWave;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Get ra WaveConfigSO hiện tại
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemies()
    {
        for (int enemyIndex = 0; enemyIndex < currentWave.GetEnemyCount(); enemyIndex++)
        {
            Instantiate(currentWave.GetEnemyPrefab(enemyIndex),
                          currentWave.GetStartingWaypoint().position,
                          Quaternion.identity,
                          transform
                          );

            yield return new  WaitForSecondsRealtime(currentWave.GetRandomSpawnTime());

        }
    }


}
