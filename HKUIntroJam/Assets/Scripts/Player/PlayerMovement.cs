using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [TextArea(3, 5)][SerializeField] string note;

    [Header("References")]
    [SerializeField] Collider2D coll;
    [SerializeField] Rigidbody2D rb2d;

    [Header("Variables")]
    [Header("Movement")]
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float jumpheight = 10f;

    [Header("Jumping")]
    [SerializeField] float groundCheckOffset = -0.6f;
    [SerializeField] LayerMask groundCheck;
    [SerializeField] float normalGravity = 1f;
    [SerializeField] float fallGravity = 2f;

    [Header("States")]
    [SerializeField] bool isGrounded;
    [SerializeField] bool isJumping;
    [SerializeField] bool canMove = true;


    [Header("AbilityStates")]
    [SerializeField] bool canJump;


    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) MovePlayer();

        GroundCheck();

        if(isGrounded && isJumping == true)
        {
            isJumping = false;
        }

        if (isGrounded)
        {
            rb2d.gravityScale = normalGravity;
        }

        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyUp(KeyCode.Space) && !isGrounded)
        {
            ChangeGravity(fallGravity);
            Debug.Log("I am let go!!!!");
        }
    }

    private void ChangeGravity(float gravity)
    {
        rb2d.gravityScale = gravity;
    }

    private void MovePlayer()
    {
        Vector2 movement = new Vector2(transform.position.x + movementSpeed * Time.deltaTime, transform.position.y);
        //Debug.Log(movement);
        transform.position = movement;
    }

    public void Jump()
    {
        if (isGrounded && canJump)
        {
            isJumping = true;
            Vector2 jumpVector = new Vector2(0, jumpheight);
            rb2d.AddForce(jumpVector, ForceMode2D.Force);
        }
    }

    public void GroundCheck()
    {
        Vector2 groundCheckOffsetVector = new Vector2(transform.position.x, transform.position.y + groundCheckOffset);
        isGrounded = Physics2D.Linecast(transform.position, groundCheckOffsetVector, groundCheck);
    }

    //private void OnDrawGizmos()
    //{
    //    Vector3 debugVector = new Vector3(transform.position.x, transform.position.y + groundCheckOffset, 0);
    //    Debug.DrawLine(transform.position, debugVector, Color.red, groundCheck);
    //}

    public void TriggerMovement(bool state)
    {
        canMove = state;
    }
}

