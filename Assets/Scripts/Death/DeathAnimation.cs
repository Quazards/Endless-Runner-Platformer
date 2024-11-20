using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    private Animator animator;
    public bool isDead = false;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void TriggerDeath()
    {
        isDead = true;
        animator.SetBool("Death", isDead);
        //animator.SetTrigger("Death");
    }
}
