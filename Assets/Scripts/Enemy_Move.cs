using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyFollow2D : MonoBehaviour
{
    [Header("Target")]
    public Transform player;

    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float stoppingDistance = 1.5f;

    private Rigidbody2D rb;

    //Variables for Ground Checking 
    public Transform groundCheck;
    public LayerMask groundLayer;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        //Vector2 direction = player.position - transform.position;
        //float distance = direction.magnitude;

        // MOVEMENT LOGIC 
        Vector2 direction = (Vector2)player.position - rb.position;
        float distance = direction.magnitude;

        //Check if there is NO ground in front of the enemy, if so, stop moving
        //RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, 1f, groundLayer);
        bool isGroundAhead = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        Debug.DrawRay(groundCheck.position, Vector2.down * 100f, Color.red, 5.0f); // Visualize the raycast in the editor


        if (distance > stoppingDistance)
        {
            if (isGroundAhead) {

                direction.Normalize();

                // We only move on the X axis to prevent "flying" toward a jumping player
                rb.linearVelocity = new Vector2(direction.x * moveSpeed, rb.linearVelocity.y);
                
                // FLIP BASED ON DIRECTION
                HandleFlip(direction.x);
            }
            else 
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
                
                HandleFlip(direction.x); // Still flip even if we can't move forward
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            rb.angularVelocity = 0f;

        }
    }

    // Flip logic
    void HandleFlip(float moveX)
    {
        if (moveX > 0.1f)
            transform.eulerAngles = new Vector3(0, 0, 0); // Face Right
        else if (moveX < -0.1f)
            transform.eulerAngles = new Vector3(0, 180, 0); // Face Left
    }
}
