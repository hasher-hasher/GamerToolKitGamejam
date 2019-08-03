using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Demo : MonoBehaviour
{
    Rigidbody2D rb;

    
    [SerializeField]
    float higherJumpTime;

    [SerializeField]
    private float moveForce;
    // Hold right position from the player to move
    private Vector2 moveTarget;

    // Coroutine handler
    private Coroutine c;
    // Bool variable for jumpCoroutine
    private bool jumpCoroutineRunning;

    private float lastTimePressed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCoroutineRunning = false;
        lastTimePressed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Update where to player move position
        moveTarget = new Vector2(transform.position.x + 1f, transform.position.y);

        // Updating any pressed button if in game
        if (Input.GetKey(KeyCode.Keypad1)) {
            // Run
            transform.position = Vector2.MoveTowards(transform.position, moveTarget, moveForce);
        }

        // Check if the player started to press the button with
        // the intention to jump
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            // Start time handler coroutine
            if (Time.time - lastTimePressed < higherJumpTime) {
                print("tei");
            }
            lastTimePressed = Time.time;
        }
    }
}
