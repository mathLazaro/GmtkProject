using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class UpgradeManager : MonoBehaviour
{
    public float upgradeRate;
    [SerializeField] private List<UpgradeController> prefabList;
    private float _upgradeTimer = 10f;

    private void Update()
    {
        _upgradeTimer -= Time.deltaTime;
        if (_upgradeTimer <= 0)
        {
            SpawnRandomUpgrade();
            _upgradeTimer = upgradeRate;
        }
    }

    void SpawnRandomUpgrade()
    {
        float angle = Random.Range(0,Mathf.PI*2);
        Vector2 position = new Vector2(Mathf.Cos(angle),Mathf.Sin(angle)) * new Vector2(22.4f, 22.4f * 9/16);
        var upgradePrefab = prefabList[Random.Range(0,prefabList.Count)];
        Instantiate(upgradePrefab, new Vector3(position.x, position.y, 0),Quaternion.identity);
    }
}