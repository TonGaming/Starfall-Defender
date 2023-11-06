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

    
}




