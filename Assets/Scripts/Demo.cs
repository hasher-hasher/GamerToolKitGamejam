using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// [RequireComponent(typeof(Rigidbody2D))]
// [RequireComponent(typeof(CircleCollider2D))]
public class Demo : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    AudioSource sourceAudio;

    public List<AudioClip> audioClips = new List<AudioClip>();

    
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

    public Text the_text;

    public Text best_text;

    public GameObject deathText;
    
    public GameObject tutorialText;

    private bool canPlay;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpCoroutineRunning = false;
        lastTimePressed = 0;
        sourceAudio = GetComponent<AudioSource>();
        canPlay = true;
        tutorialText.SetActive(true);
        best_text.text = PlayerPrefs.GetString("Best");
    }

    private void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            tutorialText.SetActive(false);
        }
        // Updating any pressed button if in game
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (canPlay) {
                bool x = false;
                int y = 0;
                x = int.TryParse(the_text.text, out y);
                the_text.text = (y + 1).ToString();
                if (int.Parse(the_text.text) > int.Parse(best_text.text)) {
                    best_text.text = the_text.text;
                }
                // Run
                rb.velocity = new Vector2(moveForce, rb.velocity.y);
                if (!isJumping)
                {
                    anim.SetTrigger("Run");
                }
            } else if (Input.GetKeyDown(KeyCode.Alpha1)) {
                SceneManager.LoadScene("TEst", LoadSceneMode.Single);
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (canPlay) {
                // Start time handler coroutine
                if (Time.time - lastTimePressed < higherJumpTime && !this.isJumping)
                {
                    sourceAudio.clip = audioClips[1];
                    sourceAudio.Play();
                    rb.velocity = Vector2.up * jumpForce; // Jump
                    anim.SetTrigger("Jump");
                }
                lastTimePressed = Time.time;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy") {
            print("Morreu otario");
            PlayerPrefs.SetString("Score", the_text.text);
            PlayerPrefs.SetString("Best", best_text.text);
            tutorialText.SetActive(false);
            deathText.SetActive(true);
            canPlay = false;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
            if (other.gameObject.tag == "Floor" && isJumping == true)
            {
                this.isJumping = false;
            }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            this.isJumping = true;
        }
    }
}
