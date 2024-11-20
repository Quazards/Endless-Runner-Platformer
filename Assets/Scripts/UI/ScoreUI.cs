using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text = "Score: " + ScoreManager.Score.ToString();
    }
}
