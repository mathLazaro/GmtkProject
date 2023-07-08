using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PrincessController princessController;
    public EnemyManager enemyManager;
    public float timer;
    public int score = 0;
    public int princessLife
    {
        get => princessController.life;
    }

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }


}