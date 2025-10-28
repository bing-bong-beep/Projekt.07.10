using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postac : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 5;
    public float jumpForce = 300;
    public float moveInput = 0;
    public Rigidbody2D rigibody2;
    public SpriteRenderer spriteRenderer;
    public GroundChecker groundChecker;
    public bool isJump = false;
    public bool DoubleJump;
    public float dashSpeed = 10f;
    public float dashDuration = 0.50f;
    public float dashCooldown = 1f;
    public bool isDashing;
    private bool canDash = true;
    public Animator anim;
  



    void Start()
    {
       rigibody2 = GetComponent<Rigidbody2D>();
       spriteRenderer = GetComponent<SpriteRenderer>();
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

         moveInput = Input.GetAxis("Horizontal");

        if (moveInput != 0)
        {
            anim.SetFloat("isRun", 1);
        }
        else
        {
            anim.SetFloat("isRun", -1);
        }

        if (isJump)
        {
            anim.SetBool("isJump", true);
        }
        else
        {
            anim.SetBool("isJump", false);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundChecker.isGrounded || DoubleJump)
            {
                isJump = true;
              //anim.SetBool("isJump", true);
            }
        }
        if ((Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded))
        {
            DoubleJump = false; 
        }

        

        if (Input.GetKey(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
       
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rigibody2.velocity = new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime, rigibody2.velocity.y);
        spriteRenderer.flipX = rigibody2.velocity.x < 0f;

        if(isJump)
        {
            rigibody2.AddForce(Vector2.up * jumpForce);
            DoubleJump = !DoubleJump;
            isJump = false;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rigibody2.velocity = new Vector2(moveInput * dashSpeed * Time.fixedDeltaTime, rigibody2.velocity.y);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

    }
}
       
