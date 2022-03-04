using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool android;

    [SerializeField] private Joystick joystick;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private Animator animator;

    private bool isGrounded = true;
    private Rigidbody2D rb;

    [HideInInspector] public bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (!android) {
            joystick.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moveInput;

        if (!android)
        {
            moveInput = Input.GetAxis("Horizontal");
        }
        else {
            moveInput = joystick.Horizontal;
        }
        
        float moveBy = moveInput * speed;

        if (moveInput != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else {
            animator.SetBool("isRunning", false);
        }

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            if (!android)
            {
                if (Input.GetAxis("Vertical") > 0 || Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    isGrounded = false;
                }
            }

            else {
                if (joystick.Vertical > 0.5) {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    isGrounded = false;
                }
            }
            
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
