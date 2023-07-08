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
    private float timer;

    private void Update() 
    {
        timer += Time.deltaTime;
        UpdateTempoUI();
    }

    public void UpdateTempoUI()
    {
        minScore.text = minutos.text = ((int)timer/60).ToString("00");
        segScore.text = segundos.text = ((int)timer%60).ToString("00");

    }
}
