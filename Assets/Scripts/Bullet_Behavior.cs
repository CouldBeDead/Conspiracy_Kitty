using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet2D : MonoBehaviour
{
    public float speed = 12f;
    public float lifeTime = 3f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }

    void Start()
    {
        // Shoot in the direction the bullet is facing
        rb.linearVelocity = transform.right * speed;

        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ignore shooter
        if (other.CompareTag("Player"))
            return;

        Destroy(gameObject);
    }
}
