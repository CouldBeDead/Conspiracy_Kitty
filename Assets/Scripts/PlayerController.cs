using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float jumpingPower = 16f;
    private int speed = 8;
    private bool isFacingRight = true;
    private telekinesisScript telekinesis;

    [SerializeField] private Rigidbody2D rB;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && isGrounded()) //Player jumps if they're on the ground and press the jump key.
        {
            rB.linearVelocity = new Vector2(rB.linearVelocity.x, jumpingPower); 
        }

        if(Input.GetButtonDown("Jump") && rB.linearVelocity.y > 0f) 
        {
            rB.linearVelocity = new Vector2(rB.linearVelocity.x, rB.linearVelocity.y * 0.5f);
        }

        if(Input.GetMouseButtonDown(0)) //Player can use telekinesis if they click the left mouse button.
        {
            print("Attempting to use telekinesis...");
           
             // 1. Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 2. Use GetRayIntersection for 2D colliders
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null) // 3. Check if the ray hit something
            {
                telekinesis = hit.collider.GetComponent<telekinesisScript>();
                print("Hit " + hit.collider.name);
                
                if (telekinesis != null)
                {
                    telekinesis.IsBeingDragged = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && telekinesis != null) //Player can stop using telekinesis if they release the left mouse button.
        {
            print("Stopping telekinesis...");
            telekinesis.IsBeingDragged = false;
            telekinesis = null;
        }

        //Flip();
    }

    private void FixedUpdate()
    {
        rB.linearVelocity = new Vector2(horizontal * speed, rB.linearVelocity.y); //Basic left and right movement.
    }

    private bool isGrounded() //Checks if the player has hit the ground or object or not.
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); 
    }
    private void Flip() //Doesn't really work. Just teleports the player to the opposite side of the scene.
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
