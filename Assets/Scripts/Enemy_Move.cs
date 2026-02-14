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

        Vector2 direction = player.position - transform.position;
        float distance = direction.magnitude;

        if (distance > stoppingDistance)
        {
            direction.Normalize();
            rb.linearVelocity = direction * moveSpeed;
        }
        else
        {
            // Fully stop and prevent drift
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
