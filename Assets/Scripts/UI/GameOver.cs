using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject hud;

    private void Update()
    {
        if(GameManager.Instance.princessLife <= 0) GameOverMenu();
    }

    private void GameOverMenu()
    {
        Time.timeScale=0f;
        gameOver.SetActive(true);
        hud.SetActive(false);
    }
}
