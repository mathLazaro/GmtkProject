using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI minutos;
    public TextMeshProUGUI segundos;
    public TextMeshProUGUI minScore;
    public TextMeshProUGUI segScore;

    private void Update() 
    {
        UpdateTempoUI();
    }

    public void UpdateTempoUI()
    {
        minScore.text = minutos.text = ((int)GameManager.Instance.timer/60).ToString("00");
        segScore.text = segundos.text = ((int)GameManager.Instance.timer%60).ToString("00");

    }
}
