using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float difficultyFactor = 1f;
    [SerializeField] private float scalingTime;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(DifficultyScaling());
    }

    private IEnumerator DifficultyScaling()
    {
        difficultyFactor++;
        yield return new WaitForSeconds(scalingTime);
    }
}
