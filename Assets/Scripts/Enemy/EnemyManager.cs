using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public float enemyRate;
    [SerializeField] private List<EnemyController> prefabList;
    private float _enemyTimer = 2f;

    private void Update()
    {
        _enemyTimer -= Time.deltaTime;
        if (_enemyTimer <= 0)
        {
            SpawnRandomEnemy();
            _enemyTimer = enemyRate;
        }
    }

    void SpawnRandomEnemy()
    {
        float angle = Random.Range(0,Mathf.PI*2);
        Vector2 position = new Vector2(Mathf.Cos(angle),Mathf.Sin(angle)) * 11.4f;
        var enemyPrefab = prefabList[Random.Range(0,prefabList.Count-1)];
        Instantiate(enemyPrefab, new Vector3(position.x, position.y, 0),Quaternion.identity);
    }
}