using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnableObjects;
    private GameManager _gameManager;
    public float spawnTime = 2f;
    public float objectSpeed = 2f;

    private void Start()
    {
        _gameManager = GameManager.Instance;

        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Spawn();

            yield return new WaitForSeconds(spawnTime);

            if (_gameManager != null)
            {

                if (spawnTime >= 0.5)
                {
                    spawnTime -= _gameManager.difficultyFactor / 100;
                }

                objectSpeed += _gameManager.difficultyFactor / 10;
            }
        }
    }

    private void Spawn()
    {
        GameObject objectToSpawn = spawnableObjects[Random.Range(0, spawnableObjects.Length)];

        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D objectBody = spawnedObject.GetComponent<Rigidbody2D>();
        objectBody.velocity = Vector2.left * objectSpeed;
    }

}
