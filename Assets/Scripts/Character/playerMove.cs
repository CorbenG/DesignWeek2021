using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private playerInput _input;
    private Rigidbody2D rb;
    private Animator anim;

    public float moveSpeed;
    public float jumpForce;
    public float groundCheckRange;
    public LayerMask walkableLayers;
    public bool grounded;

    private void Update()
    {
        move();
        detectGround();
        jump();
        
    }

    private void move()
    {
        Vector3 moveVector = new Vector3(_input.moveX,0);
        rb.MovePosition(transform.position + moveVector * moveSpeed * Time.deltaTime);
    }

    void animationControl() 
    {
        
    }

    void jump() 
    {
        if (_input.jump && grounded) 
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    void detectGround() 
    {
        grounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckRange, walkableLayers);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, Vector2.down * groundCheckRange);
    }
}
