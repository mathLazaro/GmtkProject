using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void StartGame() {SceneManager.LoadScene("MainScene");}
    public void QuitGame() {Application.Quit();}
}
