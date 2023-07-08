using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrincessController : MonoBehaviour
{
    public int life = 20;
    public Image img;

    private void Update() 
    {
        img.fillAmount = life/20f;
    }

    public void Hurt()
    {
        life--;
    }
}
