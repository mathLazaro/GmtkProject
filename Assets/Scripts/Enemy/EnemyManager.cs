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
    private float _enemyLife = 10f;

    private void Update()
    {
        enemyRate = Mathf.Max(enemyRate - Time.deltaTime * 0.005f, 0.2f);
        _enemyTimer -= Time.deltaTime;
        _enemyLife += Time.deltaTime * 0.05f;
        if (_enemyTimer <= 0)
        {
            SpawnRandomEnemy();
            _enemyTimer = enemyRate;
        }
    }

    void SpawnRandomEnemy()
    {
        float angle = Random.Range(0,Mathf.PI*2);
        Vector2 position = new Vector2(Mathf.Cos(angle),Mathf.Sin(angle)) * new Vector2(22.4f, 22.4f * 9/16);
        var enemyPrefab = prefabList[Random.Range(0,prefabList.Count)];
        var enemy = Instantiate(enemyPrefab, new Vector3(position.x, position.y, 0),Quaternion.identity);
        enemy.SetLife(_enemyLife,true);
    }
}