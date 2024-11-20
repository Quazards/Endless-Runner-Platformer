using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public bool isInvincible { get; set; }

    public UnityEvent OnDeath;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealthChange;

    public void TakeDamage(int damage)
    {
        if (currentHealth == 0)
        {
            OnDeath.Invoke();
        }

        if (isInvincible)
        {
            return;
        }

        currentHealth -= damage;
        OnHealthChange.Invoke();

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth == 0)
        {
            OnDeath.Invoke();
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void SetHealthToZero()
    {
        currentHealth = 0;
    }

    public float RemainingHealthPercentage
    {
        get
        {
            return currentHealth / maxHealth;
        }
    }
}
