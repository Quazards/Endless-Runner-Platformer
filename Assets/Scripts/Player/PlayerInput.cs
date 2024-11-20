using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Shooting _shooting;
    private Animator _animator;
    private bool isActivated = true;

    private float horizontalInput;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _shooting = GetComponent<Shooting>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        PlayerShootingInput(isActivated);
    }

    private void FixedUpdate()
    {
        //Movement
        PlayerMovementInput(isActivated);

        //Sprites and animation
        if(horizontalInput > 0 && !_playerMovement.isFacingRight)
        {
            _playerMovement.Flip();
        }
        else if(horizontalInput < 0 && _playerMovement.isFacingRight)
        {
            _playerMovement.Flip();
        }

        _animator.SetBool("Running", horizontalInput != 0);
        _animator.SetBool("Jumping", !_playerMovement.isGrounded);

    }

    public void PlayerMovementInput(bool active)
    {
        if (active)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            _playerMovement.Move(horizontalInput);

            if (Input.GetKey(KeyCode.Space))
            {
                _playerMovement.Jump();
            }
        }
    }
    private void PlayerShootingInput(bool active)
    {
        if (active)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _shooting.Shoot();

                if (!_shooting.canShoot)
                {
                    _animator.SetTrigger("Shoot");
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("R is pressed");
                _shooting.SimulateReload();
            }
        }
    }

    public void DeactivateInput()
    {
        isActivated = false;
    }

    public void PlayerdDeath()
    {
        _animator.SetTrigger("Death");
    }

}
