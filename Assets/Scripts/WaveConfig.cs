using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu ( menuName = "Wave Config", fileName = "New Wave Config")]

public class WaveConfigSO : ScriptableObject
{
    // để cài prefabs path vào 
    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemyMoveSpeed;
    
    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }
    
}
