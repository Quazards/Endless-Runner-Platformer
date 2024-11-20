using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private SpriteRenderer enemySprite;
    private float targetAlpha = 0f;
    private float duration = 1f;

    private void Awake()
    {
        enemySprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void Fade()
    {
        StartCoroutine(SpriteFade());
    }

    private IEnumerator SpriteFade()
    {
        float startAlpha = enemySprite.color.a;
        float time = 0f;


        while (time < duration)
        {
            time += Time.deltaTime;

            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, time/duration);

            enemySprite.color = new Color(1, 1, 1, newAlpha);

            yield return null;
        }
    }

    public void GainScore()
    {
        ScoreManager.Score += 500;
    }
}



