using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inceneration : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall")
        {
            Destroy(collision.gameObject);
        }
    }
}
