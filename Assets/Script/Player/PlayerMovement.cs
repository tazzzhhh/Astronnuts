using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator amin;

    [SerializeField] private LayerMask jumpableGround;

    private float speed = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;


    private enum MovementState { Idle, Running, Falling, Jumping }

    [SerializeField] private AudioSource jumpSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        amin = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        // Cập nhật vận tốc liên tục trong mỗi frame
        rb.velocity = new Vector2(speed * moveSpeed, rb.velocity.y);
        UpdateAnimation();
    }

    public void MoveLeft()
    {
        speed = -1; // Di chuyển sang trái
    }

    public void MoveRight()
    {
        speed = 1; // Di chuyển sang phải
    }

    public void StopMoving()
    {
        speed = 0; // Dừng di chuyển
    }

    public void Jump()
    {
        if (coll == null)
        {
            Debug.LogError("BoxCollider2D is null on Player 2!");
            return;
        }

        if (IsGrounded())
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void UpdateAnimation()
    {
        MovementState state;

        if (speed > 0f)
        {
            state = MovementState.Running;
            sprite.flipX = false;
        }
        else if (speed < 0f)
        {
            state = MovementState.Running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.Idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.Jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.Falling;
        }

        amin.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}