using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image healthBarForeground;
    [SerializeField] private TextMeshProUGUI healthText;

    public void UpdateHealthBar(Health _health)
    {
        healthBarForeground.fillAmount = _health.RemainingHealthPercentage;
    }

    public void UpdateHealthText(Health _health)
    {
       healthText.text = _health.currentHealth.ToString() + "/" + _health.maxHealth.ToString(); 
    }
}
