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


    void Start()
    {
       rigibody2 = GetComponent<Rigidbody2D>();
       spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         moveInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded)
        {
            isJump = true;
        }
    }

    private void FixedUpdate()
    {
        rigibody2.velocity = new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime, rigibody2.velocity.y);

        if(isJump)
        {
            rigibody2.AddForce(Vector2.up * jumpForce);
            isJump = false;
        }
    }
}
       
