using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime = 3f;
    [SerializeField] private int damage = 1;

    private void Start()
    {
        Destroy(gameObject, lifetime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var health = collision.GetComponent<Health>();
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground") || collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else
            return;
            
    }
}
