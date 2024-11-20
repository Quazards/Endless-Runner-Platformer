using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int Score;
    public int maxScore = 0;
    public int incomeAmount = 100;

    private void Start()
    {
        Score = 0;

        StartCoroutine(GenerateScore());
    }

    private IEnumerator GenerateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Score += incomeAmount;
        }
    }

    public void HighScore()
    {
        if (maxScore == 0)
        {
            maxScore = Score;
        }
        else if (maxScore > Score)
        {
            maxScore = Score;
        }
        else
            return;
    }

}
