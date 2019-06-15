using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI tentativas, score;
    private void Start()
    {
        tentativas.text = "Tentativas: " + PlayerPrefs.GetInt("Tentativas");
        score.text = "Score: " + PlayerPrefs.GetInt("Score");
    }
}
