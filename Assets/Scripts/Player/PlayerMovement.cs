using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D body;
    [HideInInspector] public bool isGrounded;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;

    private Health playerHealth;

    private float horizontalInput;
    private Vector2 lastInput;
    public bool isFacingRight;

    private int crushCount = 0;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<Health>();
    }

    public void Move(float input)
    {
        input = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(input * speed, body.velocity.y);
        
    }

    public void Jump()
    {
        if (isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
            isGrounded = false;
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void KnockBack(float amount)
    {
        float input = Input.GetAxis("Horizontal");

        if (input < 0)
        {
            transform.Translate(new Vector3(amount, 0, 0));
        }
        else if(input > 0)
        {
            transform.Translate(new Vector3(-amount, 0, 0));
        }
    }

    public void Grounded()
    {
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        else if (collision.gameObject.tag == "Wall")
        {
            crushCount++;
        }
        else if (collision.gameObject.tag == "Incenerator")
        {
            playerHealth.OnDeath.Invoke();
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(crushCount >= 2)
        {
            playerHealth.OnDeath.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            crushCount--;
        }
    }
}
