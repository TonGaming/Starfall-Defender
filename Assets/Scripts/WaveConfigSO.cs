using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu ( menuName = "Wave Config", fileName = "New Wave Config")]

public class WaveConfigSO : ScriptableObject
{
    // để cài prefabs path vào 
    [SerializeField] List<GameObject> enemyPrefabs;

    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemyMoveSpeed;

    [SerializeField] float minSpawnTime = 0.2f;
    [SerializeField] float timeVariance = 0.5f;
    [SerializeField] float timeBetweenEnemySpawn = 1f;

    // Get ra so luong cua enemy trong list
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    // get ra mot enemy cu the 
    public GameObject GetEnemyPrefab(int enemyIndex)
    {
        return enemyPrefabs[enemyIndex];
    }



    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }
    
    public List<Transform> GetWaypoints()
    {
        // tạo một list rỗng để lưu waypoints vào 
        List<Transform> waypointsList = new List<Transform>();

        // mỗi khi lặp qua một phần tử transform trong pathPrefabs thì Add phần tử đó vào list vừa tạo
        foreach (Transform child in pathPrefab)
        {
            waypointsList.Add(child);
        }

        return waypointsList;
    }

    public float GetRandomSpawnTime()
    {
        // tạo một temp value để lưu giá trị random của thời gian enemy spawn
        float spawnTime = Random.Range(timeBetweenEnemySpawn - timeVariance, 
                                            timeBetweenEnemySpawn + timeVariance);

        // Clamp tất cả các giá trị của spawnTime nằm ngoài khoảng min và max 
        return Mathf.Clamp(spawnTime, minSpawnTime, timeBetweenEnemySpawn + timeVariance);
    }

}




