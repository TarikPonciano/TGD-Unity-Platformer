using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;



    bool isGrounded;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    private float runSpeed = 4;

    [SerializeField]
    private float jumpSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }


    private void FixedUpdate()
    {

        if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Default")))
        {
            isGrounded = true;
        }

        else
        {
            isGrounded = false;
        }

        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);

            if (isGrounded)
            {
                animator.Play("player_run");
            }

            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
            {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);

            if (isGrounded)
            {
                animator.Play("player_run");
            }

            spriteRenderer.flipX = true;
        } else 
        {
            if (isGrounded)
            {
                animator.Play("player_idle");
            }
            
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (((Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("space")))  && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
    }

}
