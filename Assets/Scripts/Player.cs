using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer pistolsr;

    private float moveForce = 10f, jumpForce = 11f;

    private float movementX;

    private string GROUND_TAG = "Ground", WALK_ANIMATION = "Walk", ENEMY_TAG = "Enemy";

    private bool isGrounded = true, canJump = false;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator animator;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        AnimatePlayer();
        canPlayerJump();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMovement()
    {
        if (transform.position.x > 56.302f)
        {
            transform.position = new Vector3(56.302f, transform.position.y, 0f);
        }
        else if (transform.position.x < -56.302f)
        {
            transform.position = new Vector3(-56.302f, transform.position.y, 0f);
        }
        else
        {
            movementX = Input.GetAxisRaw("Horizontal");
            transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        }
    }

    void PlayerJump() 
    {
        if (canJump)
        {
            canJump = false;
            isGrounded = false;
            myBody.AddForce(new Vector2 (0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void canPlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
            canJump = true;
    }

    void AnimatePlayer()
    { 
        if (movementX > 0) // Going right
        {
            animator.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
            pistolsr.flipX = true;
        }
        else if (movementX < 0) // Going left
        {
            animator.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
            pistolsr.flipX = false;
        }
        else // Idle
        {
            animator.SetBool(WALK_ANIMATION, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Death");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Death");
        }
    }
}
