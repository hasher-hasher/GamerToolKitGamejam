using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Demo : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    
    [SerializeField]
    float higherJumpTime;
    [SerializeField]
    float jumpForce;

    [SerializeField]
    private float moveForce;
    // Hold right position from the player to move
    private Vector2 moveTarget;

    // Coroutine handler
    private Coroutine c;
    // Bool variable for jumpCoroutine
    private bool jumpCoroutineRunning;

    private float lastTimePressed;

    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpCoroutineRunning = false;
        lastTimePressed = 0;
    }

    private void FixedUpdate() {
        // Updating any pressed button if in game
        if (Input.GetKey(KeyCode.Keypad1))
        {
            // Run
            rb.velocity = new Vector2(moveForce, rb.velocity.y);
            if (!isJumping) {
                anim.SetTrigger("Run");
            }
        } else if (!isJumping)
        {
            anim.SetTrigger("Idle");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player started to press the button with
        // the intention to jump
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            // Start time handler coroutine
            if (Time.time - lastTimePressed < higherJumpTime && !this.isJumping) {
                rb.velocity = Vector2.up * jumpForce; // Jump
                anim.SetTrigger("Jump");
            }
            lastTimePressed = Time.time;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Floor") {
            this.isJumping = false;
            print("-> " + isJumping);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            this.isJumping = true;
            print("-> " + isJumping);
        }
    }
}
