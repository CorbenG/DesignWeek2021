using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(playerInput))]
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

    Vector2 velocity;
    float AccelerationFactor = 20f;
    float DecelerationFactor = 1.1f;
    public float MaxSpeed;

    SceneManager sceneManager;

    AudioSource audioSource;
    public float audioTiming = 0.4f;
    float nextPlayTime;
    public AudioClip defaultWalking;


    private void Start()
    {
        anim = GetComponent<Animator>();
        _input = GetComponent<playerInput>();
        rb = GetComponent<Rigidbody2D>();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
        audioSource = GetComponent<AudioSource>();
        nextPlayTime = Time.time;
    }

    private void Update()
    {
        move();
        detectGround();
        jump();
        MoveRooms();
        animationControl();
    }

    private void move()
    {
        /*
        Vector3 moveVector = new Vector3(_input.moveX,0);
        rb.MovePosition(transform.position + moveVector * moveSpeed * Time.deltaTime);
        */
        //Calculate velocty based on input
        velocity = Vector2.ClampMagnitude(velocity + new Vector2(Input.GetAxisRaw("Horizontal") * AccelerationFactor * Time.deltaTime, 0), MaxSpeed);

        //Slow down if no input
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            velocity.x = velocity.x / DecelerationFactor;
        }
        //Update position
        transform.position = new Vector3(transform.position.x + velocity.x * Time.deltaTime, transform.position.y, 0);

    }

    void animationControl() 
    {
        //Control Flipping character
        if(velocity.x > 0.2)
        {
            GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (velocity.x < -0.2)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        //Control walking animation
        if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
        //Control walking sound
        if (Time.time >= nextPlayTime && Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
        {
            nextPlayTime = Time.time + audioTiming;
            audioSource.pitch = Random.Range(0.5f, 1f);
            audioSource.PlayOneShot(defaultWalking);
        }
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

    void MoveRooms()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RightCollider")
        {
            sceneManager.currentScene.GetComponent<Room>().GoToRoom("Right");
        }
        else if (collision.gameObject.tag == "LeftCollider")
        {
            sceneManager.currentScene.GetComponent<Room>().GoToRoom("Left");
        }
    }
}
