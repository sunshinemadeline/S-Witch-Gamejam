using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public float climbSpeed = 4f;
    public float normalGravity = 3f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.25f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float moveInput;
    private float verticalInput;
    private bool isGrounded;

    private bool isClimbing = false;
    private bool isInClimbZone = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        if (!isClimbing && Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX(AudioManager.Instance.jumpSFX);
            }
        }

        if (isInClimbZone && Mathf.Abs(verticalInput) > 0.1f)
        {
            isClimbing = true;
        }

        if (!isInClimbZone)
        {
            isClimbing = false;
        }
    }

    void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(0f, verticalInput * climbSpeed);
        }
        else
        {
            rb.gravityScale = normalGravity;

            float targetVelocityX = moveInput * moveSpeed;
            rb.linearVelocity = new Vector2(targetVelocityX, rb.linearVelocity.y);
        }
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    public float GetVerticalVelocity()
    {
        return rb.linearVelocity.y;
    }

    public float GetMoveInput()
    {
        return moveInput;
    }

    public bool IsClimbing()
    {
        return isClimbing;
    }

    public void ExitClimb(Vector2 boostVelocity)
    {
        isClimbing = false;
        isInClimbZone = false;
        rb.gravityScale = normalGravity;
        rb.linearVelocity = boostVelocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Climbable"))
        {
            isInClimbZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Climbable"))
        {
            isInClimbZone = false;
            isClimbing = false;
        }
    }
}