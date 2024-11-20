using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private Health _health;
    private SpriteRenderer sprite;
    private Material startMaterial;
    [SerializeField] private Material newMaterial;
    [SerializeField] private int blinkCount;

    private void Awake()
    {
        _health = GetComponent<Health>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void StartInvincibility(float duration)
    {
        StartCoroutine(invinciblityCoroutine(duration, blinkCount));
    }

    private IEnumerator invinciblityCoroutine(float invincibilityDuration, int blinkCount)
    {
        startMaterial = sprite.material;

        _health.isInvincible = true;

        for (int i = 0; i < blinkCount; i++)
        {
            sprite.material = newMaterial;

            yield return new WaitForSeconds(invincibilityDuration / (blinkCount * 2));

            sprite.material = startMaterial;

            yield return new WaitForSeconds(invincibilityDuration / (blinkCount * 2));
        }

        _health.isInvincible = false;
    }
}
