using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] int delayTime = 1;
    [SerializeField] WaveConfigSO currentWave;

    int enemyIndex;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    // Get ra WaveConfigSO hiện tại
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    void SpawnEnemies()
    {
        for (int enemyIndex = 0; enemyIndex < currentWave.GetEnemyCount(); enemyIndex++)
        {
            

            StartCoroutine(EnemiesDelay());
            
        }
    }

    IEnumerator EnemiesDelay()
    {
        yield return new WaitForSecondsRealtime(delayTime);

        Instantiate(currentWave.GetEnemyPrefab(enemyIndex),
                          currentWave.GetStartingWaypoint().position,
                          Quaternion.identity,
                          transform
                          );

    }
}
