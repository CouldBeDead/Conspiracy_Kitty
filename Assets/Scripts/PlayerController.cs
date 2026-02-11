using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float jumpingPower = 16f;
    private int speed = 8;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rB;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            rB.linearVelocity = new Vector2(rB.linearVelocity.x, jumpingPower); 
        }

        if(Input.GetButtonDown("Jump") && rB.linearVelocity.y > 0f)
        {
            rB.linearVelocity = new Vector2(rB.linearVelocity.x, rB.linearVelocity.y * 0.5f);
        }

        //Flip();
    }

    private void FixedUpdate()
    {
        rB.linearVelocity = new Vector2(horizontal * speed, rB.linearVelocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    { 
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
