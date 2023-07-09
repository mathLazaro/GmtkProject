using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
     [SerializeField] private GameObject pauseUI;
     [SerializeField] private GameObject hud;
    public static bool isPaused;

    private void Start() {
        isPaused = false;
        pauseUI.SetActive(false);
    }

    public void Pause(bool inputPause)
    {
        if(inputPause && isPaused==false) // Serve para entrar no pause
        {
            isPaused = true;
            Time.timeScale=0f;
            pauseUI.SetActive(true);
            hud.SetActive(false);
        }
        else if(inputPause && isPaused==true) // Serve para sair do pause
        {
            isPaused = false;
            Time.timeScale=1f;
            pauseUI.SetActive(false);
            hud.SetActive(true);
        }
    }

    private void Update() 
    {
        Pause(Input.GetKeyDown(KeyCode.Escape));
    }

    public void Continuar()
    {
        isPaused = false;
        Time.timeScale=1f;
        pauseUI.SetActive(false);
        hud.SetActive(true);
    }
    public void CarregarMenu()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("MenuInicial");
    }
    public void CarregarCena()
    {
        SceneManager.LoadScene("MainScene");
    }
}
