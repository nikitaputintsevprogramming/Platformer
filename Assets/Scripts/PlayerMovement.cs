using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private Shoot shooter;


    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded = false;
    [SerializeField] float speed;
    [SerializeField] Transform playerCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] float jumpOffset;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        shooter = GetComponent<Shoot>();
    }

    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool isJumping = Input.GetButtonDown("Jump");

        if (isGrounded)
        {
            if (isJumping)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
                anim.SetTrigger("IsJump");
            }
            else
            {
                anim.SetTrigger("IsIdle");
            }
        }


        if (horizontal != 0)
        {
            if (horizontal > 0)
            {
                rigidBody.velocity = new Vector2(horizontal * speed, rigidBody.velocity.y);
                spriteRenderer.flipX = false;
            }
            else
            {
                rigidBody.velocity = new Vector2(horizontal * speed, rigidBody.velocity.y);
                spriteRenderer.flipX = true;
            }

            anim.SetBool("IsRun", true);
        }
        else 
        {
            anim.SetBool("IsRun", false);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            shooter.Shooter(horizontal);
        }

    }

    private void FixedUpdate()
    {
        Vector2 overlapCircle = playerCollider.position;
        isGrounded = Physics2D.OverlapCircle(overlapCircle, jumpOffset, groundLayer);        
    }
}