using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [TextArea(3,5)][SerializeField] string note;

    [Header("References")]
    [SerializeField] Collider2D coll;
    [SerializeField] Rigidbody2D rb2d;

    [Header("Variables")]
    [Header("Movement")]
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float jumpheight = 10f;

    [Header("States")]
    [SerializeField] bool isGrounded;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();


    }

    private void MovePlayer()
    {
        Vector2 movement = new Vector2(transform.position.x + movementSpeed * Time.deltaTime,transform.position.y);
        Debug.Log(movement);
        transform.position = movement;
    }

    public void Jump()
    {

    }
}
