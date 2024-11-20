using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int enemyDamageAmount;
    private bool isEnabled = true;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isEnabled)
        {
            if (collision.gameObject.tag == "Player")
            {
                var health = collision.gameObject.GetComponent<Health>();

                health.TakeDamage(enemyDamageAmount);

                Debug.Log("Attacking player");
            }
        }
    }

    public void DisableEnemyAttack()
    {
        isEnabled = false;
    }
}
