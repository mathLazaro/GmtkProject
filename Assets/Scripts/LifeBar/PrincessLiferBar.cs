using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrincessLiferBar : MonoBehaviour
{
    [SerializeField] private Image img;


    private void Start() {
        img = GetComponent<Image>();
    }
    private void Update() 
    {
        img.fillAmount = GameManager.Instance.princessLife/20;
    }
}
